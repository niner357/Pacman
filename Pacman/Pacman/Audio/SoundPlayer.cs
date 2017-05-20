using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Audio
{
    public class SoundPlayer : AudioPlay
    {
        public MusicPlayer MusicPlayer { get; private set; }

        private List<Sound> soundList;

        public SoundPlayer(MusicPlayer musicPlayer)
        {
            MusicPlayer = musicPlayer;
            soundList = new List<Sound>();
            soundList.Add(new Sound("energize", new MemoryStream(Properties.Resources.res_sound_energize), true));
        }

        public void PlaySound(string soundId)
        {
            Sound sound = GetSound(soundId);
            if (sound == null)
                return;
            WaveOut waveOut = CreateWaveOut(sound.SoundStream, 0.1f);
            if (waveOut == null)
                return;
            if(sound.PauseMusic)
                MusicPlayer.Pause(MusicPlayer.MusicWaveOut);
            waveOut.Play();
            waveOut.PlaybackStopped += (sender, eventArgs) =>
            {
                if (sound.PauseMusic)
                    MusicPlayer.Resume(MusicPlayer.MusicWaveOut);
            };
        }

        private Sound GetSound(string id)
        {
            foreach (Sound sound in soundList)
                if (sound.Id == id)
                    return sound;
            return null;
        }
    }
}
