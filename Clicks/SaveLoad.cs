using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimsMacros
{
    public static class SaveLoad
    {
        static string fileName = "autoSettings.xml";
        public static AutoSettings Load()
        {
            if (!File.Exists(fileName))
            {
                return new AutoSettings();
            }
            return Serialiser.Deserialize(File.ReadAllText(fileName));
        }

        public static void Save(AutoSettings autoSettings)
        {
            File.WriteAllText(fileName, Serialiser.Serialise(autoSettings));
        }
    }
}
