using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Audio
{
    public class Sound
    {
        public string Id { get; private set; }

        public Stream SoundStream { get; private set; }

        public bool PauseMusic { get; private set; }

        public Sound(string id, Stream soundSteam, bool pauseMusic)
        {
            Id = id;
            SoundStream = soundSteam;
            PauseMusic = pauseMusic;
        }
    }
}
