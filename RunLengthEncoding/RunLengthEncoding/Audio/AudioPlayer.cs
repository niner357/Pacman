using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using RunLengthEncoding.Properties;
using NAudio;
using NAudio.Wave;

namespace RunLengthEncoding.Audio
{
    public class AudioPlayer
    {
        private List<Stream> musicList;
        private Stream beforeMusicStream;
        private Random random;
        private Thread musicThread;
        public WaveOut musicWaveOut;
        public AudioPlayer()
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
        }

        public void StartPlayingRandomBackground()
        {
            musicThread = new Thread(() =>
            {
                using (WaveStream blockAlignedStream =
                new BlockAlignReductionStream(
                    WaveFormatConversionStream.CreatePcmStream(
                        new Mp3FileReader(GetRandomMusic()))))
                {
                    musicWaveOut = new WaveOut(WaveCallbackInfo.FunctionCallback());
                    musicWaveOut.Init(blockAlignedStream);
                    musicWaveOut.Volume = 0.1f;
                    musicWaveOut.Play();
                    while (musicWaveOut.PlaybackState == PlaybackState.Playing){}
                    StartPlayingRandomBackground();
                }
            });
            musicThread.Start();
        }

        public void Close()
        {
            musicThread.Abort();
        }

        private Stream GetRandomMusic()
        {
            Stream stream = musicList[random.Next(musicList.Count)];
            while(stream == beforeMusicStream) 
                stream = musicList[random.Next(musicList.Count)];
            beforeMusicStream = stream;
            stream.Position = 0;
            return stream;
        }
    }
}
