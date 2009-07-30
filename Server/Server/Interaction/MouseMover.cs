using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;


namespace Server
{
    /// <summary>
    /// Class used to move pointer and execute other mouse events by mouse event class.
    /// Mouse is moved by two threads (X and Y).
    /// </summary>
    class MouseMover
    {
        // mouse moving threads
        private Thread moveXThread;
        private Thread moveYThread;
        private int Xaccel, Yaccel;
        private bool end = false;
              
        
        /// <summary>
        /// Starts mouse moving threads.
        /// </summary>
        public void start()
        {
            end = false;
            this.moveXThread = new Thread(new ThreadStart(moveX));
            this.moveYThread = new Thread(new ThreadStart(moveY));
            this.moveYThread.Start();
            //Console.WriteLine("MOVE Y POWSTAJE!");
            this.moveXThread.Start();
            //Console.WriteLine("MOVE X POWSTAJE!");
        }

        ~MouseMover()
        {
            stop();
        }

        /// <summary>
        /// Function which calculates speed on the base of sensitivity from settings and curent acceleration.
        /// </summary>
        /// <param name="accel">acceleration</param>
        /// <returns>point where x is amount of pixels the cursor will be moved and y is time interval between moves.</returns>
        private Point speed(int accel)
        {
            return new Point((int)(Math.Abs(accel)/(15 * Properties.Settings.Default.sensitivity)), 20);
        }
        
        /// <summary>
        /// Threaded function to move cursor in X on the base of Xaccel param.
        /// </summary>
        private void moveX()
        {
            while (true)
            {
                if (end)
                    break;

                if (Xaccel < 0)
                    Cursor.Position = new Point(Cursor.Position.X - speed(Xaccel).X, Cursor.Position.Y);
                else
                    Cursor.Position = new Point(Cursor.Position.X + speed(Xaccel).X, Cursor.Position.Y);

                Thread.Sleep(speed(Xaccel).Y);
            }
            //Console.WriteLine("MOVE X Umiera...");
        }

        /// <summary>
        /// Threaded function to move cursor in Y on the base of Yaccel param.
        /// </summary>
        private void moveY()
        {
            while (true)
            {
                if (end)
                    break;

                if (Yaccel < 0)
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + speed(Yaccel).X);
                else
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - speed(Yaccel).X);

                Thread.Sleep(speed(Yaccel).Y);
            }
            //Console.WriteLine("MOVE Y Umiera...");
        }
        
        /// <summary>
        /// Processes mouse event (when not MOVE action -> execute() event, when MOVE, set Xaccel and Yaccel values).
        /// </summary>
        /// <param name="ev">event</param>
        public void doEvent(MouseEvent ev)
        {
            if (ev.act == action.MOVE)
            {
                Xaccel = ev.x;
                Yaccel = ev.y;
                //Console.WriteLine(Xaccel + " | " + Yaccel);
            }            
            else
            {
                ev.execute();
            }
        }

        /// <summary>
        /// Stops mouse moving threads.
        /// </summary>
        public void stop()
        {
            end = true;            
        }
    }
}
