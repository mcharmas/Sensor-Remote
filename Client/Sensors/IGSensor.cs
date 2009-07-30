using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.WindowsCE.Forms;

namespace Sensors
{
    public enum ScreenOrientation
    {
        Landscape = 0,
        ReverseLandscape = 1,
        Portrait = 2,
        ReversePortrait = 3, // upside down
        FaceDown = 4,
        FaceUp = 5
    }

    public struct GVector
    {
        public GVector(double x, double y, double z)
        {
            myX = x;
            myY = y;
            myZ = z;
        }
        double myX;

        public double X
        {
            get { return myX; }
            set { myX = value; }
        }
        double myY;

        public double Y
        {
            get { return myY; }
            set { myY = value; }
        }
        double myZ;

        public double Z
        {
            get { return myZ; }
            set { myZ = value; }
        }

        public GVector Normalize()
        {
            return Scale(1 / Length);
        }

        public GVector Scale(double scale)
        {
            GVector ret = this;
            ret.myX *= scale;
            ret.myY *= scale;
            ret.myZ *= scale;
            return ret;
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(myX * myX + myY * myY + myZ * myZ);
            }
        }

        public override string ToString()
        {
            return string.Format("X={0} Y={1} Z={2}", Math.Round(myX, 4), Math.Round(myY, 4), Math.Round(myZ, 4));
        }

        public ScreenOrientation ToScreenOrientation()
        {
            if (Math.Abs(X) > Math.Abs(Y))
            {
                if (Math.Abs(X) > Math.Abs(Z))
                {
                    if (X > 0)
                        return ScreenOrientation.Landscape;
                    return ScreenOrientation.ReverseLandscape;
                }
            }
            else if (Math.Abs(Y) > Math.Abs(Z))
            {
                if (Y > 0)
                    return ScreenOrientation.Portrait;
                return ScreenOrientation.ReversePortrait;
            }

            if (Z > 0)
                return ScreenOrientation.FaceDown;
            return ScreenOrientation.FaceUp;
        }
    }

    public delegate void OrientationChangedHandler(IGSensor sender);
    public interface IGSensor : IDisposable
    {
        /// <summary>
        /// Returns a vector that desribes the direction of gravity/acceleration in relation to the device screen.
        /// When the device is face up on a flat surface, this method would return 0, 0, -9.8.
        /// The Z value of -9.8 would mean that the acceleration in the opposite direction of the orientation of the screen.
        /// When the device is held up, this method would return 0, -9.8, 0.
        /// The Y value of -9.8 would mean that the device is accelerating in the direction of the bottom of the screen.
        /// Conversely, if the device is held upside down, this method would return 0, 9.8, 0.
        /// </summary>
        /// <returns>
        /// The vector returned will have a length measured in the unit meters per second square.
        /// Ideally the when the device is in a motionless state, the vector would be of length 9.8.
        /// However, the sensor is not extremely accurate, so this almost never the case.
        /// </returns>
        GVector GetGVector();

        ScreenOrientation Orientation
        {
            get;
        }

        event OrientationChangedHandler OrientationChanged;
    }

    public static class GSensorFactory
    {
        public static IGSensor CreateGSensor()
        {
            // Try the Samsung one first so it doesn't pick up the HTC accelerometer emulator
            try
            {
                return SamsungGSensor.Create();
            }
            catch (Exception)
            {
            }
            try
            {
                return HTCGSensor.Create();
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
