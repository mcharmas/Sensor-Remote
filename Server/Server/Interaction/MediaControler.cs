using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    /// <summary>
    /// Controls media player using IMediaPlayer.
    /// </summary>
    class MediaControler
    {
        private IMediaPlayer mp;
        private static string[] mediaPlayers = new string[2];
        public MediaControler()
        {
            mediaPlayers[0] = "Windows Media Player";
            mediaPlayers[1] = "Others (not supported)";
            if (Properties.Settings.Default.mediaPlayer == "Windows Media Player")
            {
                mp = new WMPControl();
                Console.WriteLine("WMP");
            }
            else
            {
                mp = new WMPControl();
                Console.WriteLine("INNY");
            }
        }

        /// <summary>
        /// Porcesses MEDIA commands. Full commands documentation in DataProcess.
        /// </summary>
        /// <param name="str">Command to parse.</param>
        public void process(string str)
        {
            if (str == "PLAY")
            {
                mp.play();
            }
            else if (str == "STOP")
            {
                mp.stop();
            }
            else if (str == "NEXT")
            {
                mp.next();
            }
            else if (str == "PREV")
            {
                mp.prev();
            }
            else if (str == "MUTE")
            {
                mp.mute();
            }
            else if (str == "VOLUP")
            {
                mp.VolUP();
            }
            else if (str == "VOLDOWN")
            {
                mp.VolDown();
            }
            else
            {
                Console.WriteLine("MediaControler UNKNOWN: " + str);
            }
        }

        /// <summary>
        /// Players.
        /// </summary>
        /// <returns>Array of available players.</returns>
        public static string[] players()
        {
            return mediaPlayers;
        }
    }
}
