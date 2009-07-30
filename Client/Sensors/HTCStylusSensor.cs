using System;
using Microsoft.WindowsMobile.Status;
using System.Collections.Generic;
using System.Text;

namespace Sensors
{
    public class HTCStylusSensor : IStylusSensor
    {
        RegistryState myStylusState = new RegistryState(@"HKEY_CURRENT_USER\ControlPanel\Keybd", "StylusOutStatus");

        public HTCStylusSensor()
        {
            myStylusState.Changed += new ChangeEventHandler(myStylusState_Changed);
        }

        void myStylusState_Changed(object sender, ChangeEventArgs args)
        {
            if (StylusStateChanged != null)
                StylusStateChanged(this);
        }

        #region IStylusSensor Members

        public StylusState StylusState
        {
            get
            {
                return (StylusState)myStylusState.CurrentValue;
            }
        }

        public event StylusEventHandler StylusStateChanged;

        #endregion
    }
}
