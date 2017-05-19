using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.IO;

namespace Pacman.Audio
{
    public abstract class AudioPlay
    {
        public WaveOut CreateWaveOut(Stream audioStream, float vol)
        {
            WaveStream waveStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(audioStream)));
            WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback());
            waveOut.Init(waveStream);
            waveOut.Volume = vol;
            return waveOut;
        }

        public void Play(WaveOut waveOut)
        {
            waveOut.Play();
        }

        public void Stop(WaveOut waveOut)
        {
            waveOut.Stop();
        }

        public void Pause(WaveOut waveOut)
        {
            if(waveOut.PlaybackState != PlaybackState.Paused)
                waveOut.Pause();
        }

        public void Resume(WaveOut waveOut)
        {
            if (waveOut.PlaybackState == PlaybackState.Paused)
                waveOut.Resume();
        }

    }
}
