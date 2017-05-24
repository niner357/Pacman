using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Audio
{
    public class AudioPlayer
    {
        public MusicPlayer MusicPlayer { get; private set; }

        public SoundPlayer SoundPlayer { get; private set; }

        public AudioPlayer()
        {
            MusicPlayer = new MusicPlayer();
            SoundPlayer = new SoundPlayer(MusicPlayer);
        }
    }
}
