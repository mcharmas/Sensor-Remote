using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Remote
{
    /// <summary>
    /// Class used to access / save settings stored in registry.
    /// </summary>
    class Settings
    {
        static private String PATH = Registry.CurrentUser + "\\Software\\RemoteControlPC\\";
        
        /// <summary>
        /// Saves setting in registry.
        /// </summary>
        /// <param name="valuename">Name of setting.</param>
        /// <param name="value">Value of setting.</param>
        public static void save(String valuename, object value)
        {
            Registry.SetValue(PATH, valuename, value);
        }

        /// <summary>
        /// Gets setting value from registry.
        /// </summary>
        /// <param name="valuename">Name of setting.</param>
        /// <returns>Value of setting.</returns>
        public static object get(string valuename)
        {
            return Registry.GetValue(PATH, valuename, null);
        }
    }
}
