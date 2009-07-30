using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Remote
{
    /// <summary>
    /// Class handling KeyEvents.
    /// Methods in this class are binded to all tab modules.
    /// </summary>
    class KeyHandler
    {
        public static sendFunction sw = null;

        /// <summary>
        /// Key down event handler.
        /// Sends "KEY {c}" commands.
        /// c depends on pressed physical button.
        /// Locks buttons when ENTER pressed.
        /// Sets event as handled so as to prevent other controls to process it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                send("KEY {UP};");
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                send("KEY {DOWN};");
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
                send("KEY {LEFT};");
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
                send("KEY {RIGHT};");
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter                
                send("KEY {ENTER};");
                PressButton.locked = true;
            }
            e.Handled = true;                
        }

        /// <summary>
        /// Key press event handler.
        /// Used to grab physical / virtual keyboard events.
        /// Sends "KEY {c}" to server.
        /// c depends on key pressed.
        /// Locks buttons when SPACE pressed setting PressButton.locked static variable to true.
        /// Sets event as handled.
        /// ";" is "KEY {SEMICOLON};"
        /// " " is "KEY {SPACE};"        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void KeyPress(object sender, KeyPressEventArgs e)
        {
            string ch;
            ch = "{" + e.KeyChar + "}";
            if (e.KeyChar != (char)System.Windows.Forms.Keys.Enter)
            {
                if (e.KeyChar == (char)System.Windows.Forms.Keys.Space)
                {
                    PressButton.locked = true;
                    send("KEY {SPACE};");
                }

                else if (e.KeyChar == ';')
                {
                    send("KEY {SEMICOLON};");
                }
                else
                {
                    send("KEY " + ch + ";");
                }
            }
            e.Handled = true;                  
        }

        /// <summary>
        /// Sw delegate wrapper checking if sw != null.
        /// </summary>
        /// <param name="str">String to send.</param>
        public static void send(string str)
        {
            if(sw != null)
            {
                sw(str);
            }
        }               

    }
}
