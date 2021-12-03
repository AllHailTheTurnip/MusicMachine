using System;
using System.Linq;
using NAudio.Wave.SampleProviders;

namespace MusicMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            Random random = new Random();

            int Average(int weight, int min, int max)
            {
                int value = 0;

                for (int i = 0; i < weight; i++)
                {
                    value += random.Next(min, max);
                }

                value /= weight;

                return value;
            }


            while (true)
            {
                // Gain.
                const double gain = 0.2;
                
                // Frequency.
                const int frequencyMin = 0;
                const int frequencyMax = 2000;
                int frequency = random.Next(frequencyMin, frequencyMax);
                
                // Duration.
                const int durationMin = 100;
                const int durationMax = 500;
                int randomDuration = random.Next(durationMin, durationMax);
                TimeSpan duration = TimeSpan.FromMilliseconds(randomDuration);
                
                // Type.
                SignalGeneratorType[] signals = new SignalGeneratorType[]
                {
                    SignalGeneratorType.Sin,
                    SignalGeneratorType.Square,
                    SignalGeneratorType.Sweep,
                    SignalGeneratorType.Triangle,
                    SignalGeneratorType.SawTooth
                };
                const int minSignalSelection = 0;
                int maxSignalSelection = signals.Count();
                int signalIndex = random.Next(minSignalSelection, maxSignalSelection);
                SignalGeneratorType type = signals[signalIndex];
                

                generator.Tone(type, gain, frequency, duration);
            }
        }
    }
}