using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Diagnostics;

namespace Pac_Man
{
    public class log
    {
        private string filepath = "./logs/logtest.txt";

        public void createLog()
        {
            FileStream fs = File.Create(filepath);

            if (File.Exists(filepath))
            {
                Debug.WriteLine("Log was created");
            }
            else
            {
                Debug.WriteLine("A problem accured while creating the log, retrying");
                createLog();
            }
        }

        public void updateLog(string text)
        {
            FileStream fs = File.Open(filepath, FileMode.Open);

            File.WriteAllText(filepath, text);
        }
    }
}
