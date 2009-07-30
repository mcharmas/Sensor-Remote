using System;
using System.Collections.Generic;
using System.Text;

namespace Sensors
{
    public enum StylusState
    {
        StylusOut = 1,
        StylusIn = 0,
    }

    public delegate void StylusEventHandler(IStylusSensor sensor);

    public interface IStylusSensor
    {
        StylusState StylusState
        {
            get;
        }

        event StylusEventHandler StylusStateChanged;
    }
}
