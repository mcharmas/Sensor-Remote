using System;
using System.Collections.Generic;
using System.Text;

namespace Sensors
{
    public delegate void NavSensorMoveHandler(double rotationsPerSecond, double radialDelta);

    public interface INavSensor
    {
        event NavSensorMoveHandler Rotated;
    }
}
