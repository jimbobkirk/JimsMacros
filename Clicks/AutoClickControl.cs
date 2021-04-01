using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace JimsMacros
{
    public partial class AutoClickControl : UserControl
    {
        bool keepRunning = true;
        bool isRunning = false;
        bool isRunningAuto = false;

        public delegate void OnDelete(AutoClickControl autoClickControl);
        public event OnDelete OnDeleteClick;

        public AutoSetting autoSetting = new AutoSetting();

        public AutoClickControl()
        {
            InitializeComponent();
            Stop();
        }

        public void Start()
        {
            UpdateSetings();
            btnStart.BackColor = Color.Red;
            btnStop.BackColor = Color.Green;
            Thread thread = new Thread(new ThreadStart(RunLooped));
            thread.Start();
        }

        public void Stop()
        {
            keepRunning = false;
            btnStart.BackColor = Color.Green;
            btnStop.BackColor = Color.Red;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        public void SetSettingsFromSettings(AutoSetting autoSetting)
        {
            this.txtName.Text = autoSetting.label;
            this.autoSetting = autoSetting;
            txtTimeBeforeBreak.Text = autoSetting.breakBetweenNextLoop.ToString();
            txtTimesBeforeRest.Text = autoSetting.timesToRunBeforeBreak.ToString();
            rdbClick.Checked = autoSetting.doClick;
            rdbButton.Checked = autoSetting.doKeyPress;
            txtKey.Text = autoSetting.keyToPress;
            chkHoldShift.Checked = autoSetting.holdShift;
            chkAutoStart.Checked = autoSetting.autoStart;
            txtHoldTime.Text = autoSetting.holdTime.ToString();
        }

        public void UpdateSetings()
        {
            autoSetting.breakBetweenNextLoop = Convert.ToInt32(txtTimeBeforeBreak.Text);
            autoSetting.timesToRunBeforeBreak = Convert.ToInt32(txtTimesBeforeRest.Text);
            if (rdbClick.Checked)
            {
                autoSetting.doClick = true;
                autoSetting.doKeyPress = false;
            }
            else
            {
                autoSetting.doClick = false;
                autoSetting.doKeyPress = true;
                autoSetting.keyToPress = txtKey.Text;
                autoSetting.holdShift = chkHoldShift.Checked;
            }
            autoSetting.label = txtName.Text;
            autoSetting.autoStart = chkAutoStart.Checked;
            autoSetting.holdTime = Convert.ToInt32(txtHoldTime.Text);
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            //e.SuppressKeyPress = true;
            //e.Handled = true;
            //txtKey.Text = e.KeyCode.ToString();
        }

        public bool ShouldDoClick
        {
            get
            {
                return rdbClick.Checked;
            }
            set
            {
                rdbClick.Checked = value;
            }
        }

        public bool ShouldDoKey
        {
            get
            {
                return rdbButton.Checked;
            }
            set
            {
                rdbButton.Checked = value;
            }
        }

        public string SetKey
        {
            get
            {
                return txtKey.Text;
            }
            set
            {
                txtKey.Text = value;
            }
        }

        public string LabelText
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        private void Run()
        {
            if (isRunning)
                return;
            isRunning = true;

            keepRunning = true;
            for (int i = 0; i < autoSetting.timesToRunBeforeBreak; i++)
            {
                if (!keepRunning)
                {
                    isRunning = false;
                    return;
                }
                if (autoSetting.doClick)
                {
                    DoClick();
                }
                else
                {
                    PressKey(autoSetting.keyToPress);
                }
            }
            isRunning = false;
        }

        private void DoClick()
        {
            MouseOperations.DoMouseClick();
            System.Threading.Thread.Sleep(autoSetting.holdTime);
            //MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            //System.Threading.Thread.Sleep(autoSetting.holdTime);
            //MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
        }

        private void PressKey(string key)
        {
            string keyCode = key;
            if (autoSetting.holdShift)
            {
                keybd_event(0x10, 0, KEY_DOWN_EVENT, 0);
            }

            switch (key)
            {
                case "Space":
                case " ":
                    SendKeys.SendWait(" ");
                    System.Threading.Thread.Sleep(autoSetting.holdTime);
                    break;
                default:
                    KeyboardKeyDown(key[0]);
                    System.Threading.Thread.Sleep(autoSetting.holdTime);
                    KeyboardKeyUp(key[0]);
                    break;
            }
            if (autoSetting.holdShift)
            {
                keybd_event(0x10, 0, KEY_UP_EVENT, 0);
            }
        }

        private void RunLooped()
        {
            if (isRunningAuto)
                return;
            isRunningAuto = true;
            keepRunning = true;
            System.Threading.Thread.Sleep(3000); //delay before it starts
            while (keepRunning)
            {
                Run();
                System.Threading.Thread.Sleep(autoSetting.breakBetweenNextLoop);
                if (!keepRunning)
                {
                    isRunningAuto = false;
                    return;
                }
            }
            isRunningAuto = false;
        }


        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int KEY_DOWN_EVENT = 0x0001; //Key down flag
        const int KEY_UP_EVENT = 0x0002; //Key up flag
        [DllImport("user32.dll", SetLastError = true)]
        static extern byte MapVirtualKey(long wCode, long wMapType);

        public static void HoldKey(byte key, int duration)
        {
        }

        private void KeyboardKeyDown(char key)
        {
            keybd_event(Convert.ToByte(key), 0, KEY_DOWN_EVENT, 0);
        }

        private void KeyboardKeyUp(char key)
        {
            keybd_event(Convert.ToByte(key), 0, KEY_UP_EVENT, 0);
        }

        public class MouseOperations
        {
            [Flags]
            public enum MouseEventFlags
            {
                LeftDown = 0x00000002,
                LeftUp = 0x00000004,
                MiddleDown = 0x00000020,
                MiddleUp = 0x00000040,
                Move = 0x00000001,
                Absolute = 0x00008000,
                RightDown = 0x00000008,
                RightUp = 0x00000010
            }

            [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool SetCursorPos(int x, int y);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool GetCursorPos(out MousePoint lpMousePoint);

            [DllImport("user32.dll")]
            private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

            public static void SetCursorPosition(int x, int y)
            {
                SetCursorPos(x, y);
            }

            public static void SetCursorPosition(MousePoint point)
            {
                SetCursorPos(point.X, point.Y);
            }

            public static MousePoint GetCursorPosition()
            {
                MousePoint currentMousePoint;
                var gotPoint = GetCursorPos(out currentMousePoint);
                if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
                return currentMousePoint;
            }

            public static void MouseEvent(MouseEventFlags value)
            {
                MousePoint position = GetCursorPosition();

                mouse_event
                    ((int)value,
                     position.X,
                     position.Y,
                     0,
                     0)
                    ;
            }

            public static void DoMouseClick()
            {
                //Call the imported function with the cursor's current position
                uint X = (uint)Cursor.Position.X;
                uint Y = (uint)Cursor.Position.Y;
                MouseEvent(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp);
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct MousePoint
            {
                public int X;
                public int Y;

                public MousePoint(int x, int y)
                {
                    X = x;
                    Y = y;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnDeleteClick(this);
        }
    }
}
