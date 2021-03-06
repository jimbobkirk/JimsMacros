using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JimsMacros
{
    public partial class Form1 : Form
    {
        KeyHandler keyHandlerStart;
        KeyHandler keyHandlerStop;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.ColumnCount = 0;
            var autoSettings = SaveLoad.Load();
            foreach(var setting in autoSettings.settings)
            {
                AutoClickControl autoClickControl = new AutoClickControl();
                autoClickControl.SetSettingsFromSettings(setting);
                AddLayoutControl(autoClickControl);
            }
            RegisterHotkeys();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotkeys();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey(m.WParam.ToInt32());
            base.WndProc(ref m);
        }

        private void HandleHotkey(int key)
        {
            if (key == keyHandlerStart.GetHashCode())
            {
                StartAll();
            }
            if (key == keyHandlerStop.GetHashCode())
            {
                StopAll();
            }
        }

        private void RegisterHotkeys()
        {
            keyHandlerStart = new KeyHandler(Keys.F7, this);
            keyHandlerStart.Register();
            keyHandlerStop = new KeyHandler(Keys.F8, this);
            keyHandlerStop.Register();
        }

        private void UnregisterHotkeys()
        {
            keyHandlerStart.Register();
        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            AddLayoutControl(new AutoClickControl());
        }

        private void AddLayoutControl(AutoClickControl ctrl)
        {
            ctrl.OnDeleteClick += Ctrl_OnDeleteClick;
            tableLayoutPanel1.Controls.Add(ctrl);
        }

        private void Ctrl_OnDeleteClick(AutoClickControl autoClickControl)
        {
            tableLayoutPanel1.Controls.Remove(autoClickControl);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AutoSettings autoSettings = new AutoSettings();
            foreach(var cotrl in tableLayoutPanel1.Controls)
            {
                AutoClickControl ctrl = ((AutoClickControl)cotrl);
                ctrl.UpdateSetings();
                ctrl.Dock = DockStyle.Fill;
                autoSettings.settings.Add(ctrl.autoSetting);
            }
            SaveLoad.Save(autoSettings);
        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            StartAll();
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            StopAll();
        }

        private void StartAll()
        {
            foreach (var cotrl in tableLayoutPanel1.Controls)
            {
                AutoClickControl ctrl = ((AutoClickControl)cotrl);
                if (ctrl.autoSetting.autoStart)
                {
                    ctrl.Start();
                }
            }
        }
        private void StopAll()
        {
            foreach (var cotrl in tableLayoutPanel1.Controls)
            {
                AutoClickControl ctrl = ((AutoClickControl)cotrl);
                ctrl.Stop();
            }
        }
    }
}