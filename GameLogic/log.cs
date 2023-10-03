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
        private string filepath = @"C:\Users\FDeubner\Documents\GitHub\Fyn\logs\log"+ System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
        private bool state = false;

        public void createLog()
        {
            byte[] info = Encoding.UTF8.GetBytes(filepath + " File was created");

            if (File.Exists(filepath) != true)
            {
                using (FileStream fs = File.Create(filepath))
                {
                    fs.Write(info, 0, Buffer.ByteLength(info));
                    fs.Close();
                }

                state = true;
            }
        }

        public void updateLog(string text)
        {
            if (File.Exists(filepath) == true)
            {
                FileStream fs = File.Open(filepath, FileMode.Open);

                byte[] info = new UTF8Encoding(true).GetBytes(text);
                fs.Write(info, 0, Buffer.ByteLength(info));

                byte[] newLine = Encoding.UTF8.GetBytes(Environment.NewLine);
                fs.Write(newLine, 0, newLine.Length);
            }

            else
            {

            }
        }

        public void updateLogTimeStamp(string text)
        {
            if (state == true)
            {
                FileStream fs = File.Open(filepath, FileMode.Open);

                byte[] info = new UTF8Encoding(true).GetBytes(System.DateTime.Now + " " + text);
                fs.Write(info, 0, Buffer.ByteLength(info));

                byte[] newLine = Encoding.UTF8.GetBytes(Environment.NewLine);
                fs.Write(newLine, 0, newLine.Length);
            }
            else
            {
                Debug.WriteLine("Log File wasnt created, retrying");
                createLog();
            }

        }
    }
}
