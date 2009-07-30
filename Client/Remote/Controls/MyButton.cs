using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Remote
{
    /// <summary>
    /// Button class provided to have mouseDown and mouseUP events. Also has downCommand and upCommand parameters.
    /// </summary>
    class MyButton : Panel
    {
        private Color c = Color.DarkOrange;
        public string downC = "";
        public string upC = "";
        public string txt = "";

        public string text
        {
            get { return txt; }
            set { txt = value; }
        }

        /// <summary>
        /// Button stores commands to limit event handling functions.
        /// </summary>
        public string downCommand
        {
            get { return downC; }
            set { downC = value; }
        }

        /// <summary>
        /// Button stores commands to limit event handling functions.
        /// </summary>
        public string upCommand
        {
            get { return upC; }
            set { upC = value; }
        }

        /// <summary>
        /// Paints the button. (Rectangle and string).
        /// String is drawn in wrong place - TODO.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen RedPen = new Pen(c, 5);
            e.Graphics.DrawRectangle(RedPen, new Rectangle(2, 2, this.Size.Width-5, this.Size.Height-5));
            e.Graphics.DrawString(txt, new Font("Tahoma", 8F, FontStyle.Regular), new SolidBrush(Color.Black), 10, 10);
        }

        /// <summary>
        /// Sets color of a button.
        /// </summary>
        /// <param name="c">color</param>
        public Color color
        {
            set
            {
                this.color = value;
                Update();
            }
            get
            {
                return this.color;
            }            
        }

    }
}
