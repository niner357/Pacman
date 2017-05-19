using NAudio.Wave;
using Pacman.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Audio
{
    public class MusicPlayer : AudioPlay
    {
        private List<Stream> musicList;
        private Stream beforeMusicStream;
        private Random random;

        public WaveOut MusicWaveOut { get; private set; }

        public MusicPlayer()
        {
            random = new Random();
            musicList = new List<Stream>();
            musicList.Add(new MemoryStream(Resources.res_music1));
            musicList.Add(new MemoryStream(Resources.res_music2));
            musicList.Add(new MemoryStream(Resources.res_music3));
            musicList.Add(new MemoryStream(Resources.res_music4));
            musicList.Add(new MemoryStream(Resources.res_music5));
            musicList.Add(new MemoryStream(Resources.res_music6));
            musicList.Add(new MemoryStream(Resources.res_music7));
            musicList.Add(new MemoryStream(Resources.res_music8));
            musicList.Add(new MemoryStream(Resources.res_music9));
            musicList.Add(new MemoryStream(Resources.res_music10));
            musicList.Add(new MemoryStream(Resources.res_music11));
            musicList.Add(new MemoryStream(Resources.res_music12));
            musicList.Add(new MemoryStream(Resources.res_music13));
            musicList.Add(new MemoryStream(Resources.res_music14));
            musicList.Add(new MemoryStream(Resources.res_music15));
            musicList.Add(new MemoryStream(Resources.res_music16));
            musicList.Add(new MemoryStream(Resources.res_music17));
            musicList.Add(new MemoryStream(Resources.res_music18));
            musicList.Add(new MemoryStream(Resources.res_music19));
            musicList.Add(new MemoryStream(Resources.res_music20));
            MusicWaveOut = CreateWaveOut(GetRandomMusic(), 0.1f);
        }

        public void PlayNext()
        {
            MusicWaveOut = CreateWaveOut(GetRandomMusic(), 0.1f);
            Play(MusicWaveOut);
        }

        private Stream GetRandomMusic()
        {
            Stream stream = musicList[random.Next(musicList.Count)];
            while (stream == beforeMusicStream)
                stream = musicList[random.Next(musicList.Count)];
            beforeMusicStream = stream;
            stream.Position = 0;
            return stream;
        }
    }
}
