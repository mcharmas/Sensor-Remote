using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    /// <summary>
    /// Class processing all the data from Server and dividing commands between MouseMover, KeyPresser and MediaControler.
    /// </summary>
    class DataProcess
    {
        MouseMover mv = new MouseMover();
        KeyPresser kp = new KeyPresser();
        MediaControler mc = new MediaControler();
        ~DataProcess()
        {
            mv.stop();            
        }       

        /// <summary>
        /// Stops MouseMover threads.
        /// </summary>
        public void stop()
        {
            mv.stop();
        }

        /// <summary>
        /// Starts MouseMover threads.
        /// </summary>
        public void start()
        {
            mv.start();
        }

        /// <summary>
        /// Parses input data and divides between MouseMover, KeyPresser and MediaControler.
        /// - commands are splited with ;
        /// - mouse commands:
        ///   - LDOWN - left button down
        ///   - RDOWN - right button down
        ///   - LUP - left button up
        ///   - RUP - right button up
        ///   - x y - mouse acceleration in x and y directions
        ///   - SCROLL x - scroll function - not working?!
        ///   - STOP - stops the mouse
        /// - key commands:
        ///   - starts with "KEY"
        ///   - everything according to msdn SendKeys documentation except " " which is "KEY {SPACE};"
        ///   - KEY {MINIMIZE} minimizes active window
        ///   - ";" is KEY {SEMICOLON};
        /// - media commands:
        ///   - starts with MEDIA
        ///   - PLAY / STOP / PAUSE / NEXT / PREV / VOLUP / VOLDOWN
        /// 
        /// 
        /// </summary>
        /// <param name="txt">input string to parse</param>
        public void process(string txt)
        {
            string[] splited = txt.Split(';');
            foreach (String s in splited)
            {
                string[] ss = s.Split(' ');
   
                if (ss[0] == "LDOWN")
                {
                    mv.doEvent(new MouseEvent(action.LEFT_DOWN));
                }

                else if (ss[0] == "RDOWN")
                {
                    mv.doEvent(new MouseEvent(action.RIGHT_DOWN));
                }

                else if (ss[0] == "LUP")
                {
                    mv.doEvent(new MouseEvent(action.LEFT_UP));
                }

                else if (ss[0] == "RUP")
                {
                    mv.doEvent(new MouseEvent(action.RIGHT_UP));
                }

                else if (ss[0] == "STOP")
                {
                    mv.doEvent(new MouseEvent(0, 0));
                }

                else if (ss[0] == "KEY")
                {
                    kp.pressKey(ss[1]);
                }

                else if (ss[0] == "MEDIA")
                {
                    mc.process(ss[1]);
                }

                else if (ss[0] == "SCROLL")
                {
                    mv.doEvent(new MouseEvent(action.SCROLL, Convert.ToInt32(ss[1], 10), 0));
                }

                else if (ss.Length == 2)
                {
                    mv.doEvent(new MouseEvent(Convert.ToInt32(ss[0], 10), Convert.ToInt32(ss[1], 10)));
                }
            }
        }
    }
}
