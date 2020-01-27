using System;
using System.Diagnostics;
using System.Text;

namespace StringConcatination
{
    class Program
    {
        static void Main(string[] args)
        {
            const int cycles = 500000;
            long MeasureConcatination()
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                string s = "a";
                for (int i = 0; i < cycles; i++)
                {
                    s = s + "a";
                }
                sw.Stop();
                return sw.ElapsedMilliseconds;
            }
            
            long MeasureStringBuilder()
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var sb = new StringBuilder(cycles);
                for (int i = 0; i < cycles; i++)
                {
                    sb.Append("a");
                }
                sb.ToString();
                sw.Stop();
                return sw.ElapsedMilliseconds;
            }

            // Warmup, in case some initial work may effect the measurement
            MeasureConcatination();
            MeasureStringBuilder();
            
            var concatTime = MeasureConcatination();
            var builderTime = MeasureStringBuilder();

            Console.WriteLine($"Concatination took {concatTime} msecs");
            Console.WriteLine($"String bulider took {builderTime} msecs");

            Console.WriteLine($"Builder to concat ratio: {(1.0 * concatTime)/builderTime}");
        }
    }
}
