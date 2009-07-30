using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    /// <summary>
    /// Interface to handle multiple media players controll.
    /// </summary>
    interface IMediaPlayer
    {
        void play();

        void pause();

        void stop();

        void next();

        void prev();

        void VolUP();

        void VolDown();

        void mute();
    }
}
