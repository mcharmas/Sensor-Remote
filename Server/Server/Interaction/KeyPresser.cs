using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    class KeyPresser
    {
        /// <summary>
        /// Presses the key according to KeyPress msdn doc's.
        /// {SPACE} -> " "
        /// {SEMICOLON} -> ";"
        /// {MINIMIZE} -> "% ", "m" - this works in Polish version, for english it is "n"
        /// </summary>
        /// <param name="s">String to parse and execute.</param>
        public void pressKey(string s)
        {
            Console.WriteLine("Pressing: " + s);
            try
            {
                if (s == "{SPACE}")
                {
                    SendKeys.SendWait(" ");
                }
                else if (s == "{SEMICOLON}")
                {
                    SendKeys.SendWait(";");
                }
                else if (s == "{MINIMIZE}")
                {
                    SendKeys.SendWait("% ");
                    SendKeys.SendWait("m");                  
                }
                else
                {
                    SendKeys.SendWait(s);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Unknown symbol.");
            }
        }       
    }
}
