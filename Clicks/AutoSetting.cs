using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimsMacros
{
    public class AutoSetting
    {
        public string label = "Click";
        public int timesToRunBeforeBreak = 5;
        public int breakBetweenNextLoop = 5000;
        public bool doClick = true;
        public bool doKeyPress = false;
        public string keyToPress = "";
        public bool holdShift = false;
        public bool autoStart = true;
        public int holdTime = 10;
        public int delay = 3000;
    }
}
