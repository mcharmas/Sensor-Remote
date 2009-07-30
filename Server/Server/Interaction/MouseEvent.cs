using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Server
{
    /// <summary>
    /// Type of mouse action.
    /// </summary>
    enum action { LEFT_DOWN, RIGHT_DOWN, LEFT_UP, RIGHT_UP, MOVE, SCROLL };

    /// <summary>
    /// Class holding mouse event and parameters.
    /// Executes mouse presses and scrolling.
    /// Class MouseMover is between DataProcess and MouseEvent.
    /// </summary>
    class MouseEvent
    {
        
        /// <summary>
        /// WinAPI function used to simulate mouse actions
        /// </summary>
        /// <param name="dwFlags">MOUSEEVENTF_* const - tells what action</param>
        /// <param name="dx">x coordinate</param>
        /// <param name="dy">y coordinate</param>
        /// <param name="cButtons"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        /// <summary>
        /// WinAPI function used for scrolling. (Ac. to  msdn mouse_event shound work but it doesn't?!)
        /// </summary>
        /// <param name="nInputs"></param>
        /// <param name="pInputs"></param>
        /// <param name="cbSize"></param>
        /// <returns></returns>
        [DllImport("User32.dll", SetLastError = true)]
        public static extern int SendInput(int nInputs, ref INPUT pInputs, int cbSize);

        /// <summary>
        /// Struct used by SendInput.
        /// </summary>
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        /// <summary>
        /// Struct used by SendInput.
        /// </summary>
        public struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        };

        // mouse actions const's
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int MOUSEEVENTF_WHEEL = 0x800;
        private const int MOUSEEVENTF_MIDDLEUP = 0x40;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        private const int WHEEL_DELTA = 120;

        public int x;
        public int y;
        public action act;

        /// <summary>
        /// Constructor with two acceleration parameters setting action as MOVE.
        /// This event will be handled by MouseMover.
        /// </summary>
        /// <param name="x">x acceleration</param>
        /// <param name="y">y acceleration</param>
        public MouseEvent(int x, int y)
        {
            this.x = x;
            this.y = y;
            act = action.MOVE;
        }

        /// <summary>
        /// Executes mouse click / scroll action.
        /// </summary>
        public void execute()
        {
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            if (act == action.RIGHT_UP)
                mouse_event(MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
            else if (act == action.RIGHT_DOWN)
                mouse_event(MOUSEEVENTF_RIGHTDOWN, X, Y, 0, 0);
            else if (act == action.LEFT_UP)
                mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            else if (act == action.LEFT_DOWN)
                mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
            else if (act == action.SCROLL)
            {
                INPUT i = new INPUT();
                i.type = 0;
                i.mi.dx = 0;
                i.mi.dy = 0;
                i.mi.dwFlags = MOUSEEVENTF_WHEEL;
                i.mi.dwExtraInfo = IntPtr.Zero;
                i.mi.mouseData = x * Properties.Settings.Default.scrollSpeed;
                i.mi.time = 0;
                //send the input 
                SendInput(1, ref i, Marshal.SizeOf(i));
                

            }
            else
                Console.WriteLine("Nie Obslugiwana akcja mysza!");
        }

        /// <summary>
        /// Constructor setting x,y accel to 0. It let's to set action.
        /// </summary>
        /// <param name="act">Mouse Event action</param>
        public MouseEvent(action act)
        {
            x = 0;
            y = 0;
            this.act = act;
        }

        /// <summary>
        /// Here you can set all parameters. Used only with scrolling.
        /// </summary>
        /// <param name="act">action</param>
        /// <param name="x">x acceleration</param>
        /// <param name="y">y acceleration</param>
        public MouseEvent(action act, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.act = act;
        }
    }
}
