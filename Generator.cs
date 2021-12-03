using System;
using System.Threading;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace MusicMachine
{
    public class Generator
    {
        public void Sine(double gain, int frequency, TimeSpan duration)
        {
            var gen = new SignalGenerator()
            {
                Gain = gain, Frequency = frequency, Type = SignalGeneratorType.Sin
            }.Take(duration);
            
            using (var wo = new WaveOutEvent())
            {
                wo.Init(gen);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                }
            }
        }

        public void Tone(SignalGeneratorType type, double gain, int frequency, TimeSpan duration)
        {
            var gen = new SignalGenerator()
            {
                Gain = gain, Frequency = frequency, Type = type
            }.Take(duration);
            
            using (var wo = new WaveOutEvent())
            {
                wo.Init(gen);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                }
            }
        }
    }
}