using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var timeArrayList = MeasureArrayList();
            var timeNativeArray = MeasureArray();
            var timeGenericList = MeasureGenericList();

            Console.WriteLine($"Array list: {timeArrayList} msec");
            Console.WriteLine($"Nativ array list: {timeNativeArray} msec");
            Console.WriteLine($"Generic list: {timeGenericList} msec");
        }

        private const int Cycles = 1000000;

        static long MeasureArrayList()
        {
            return MeasureTime(() =>
            {
                var lst = new ArrayList(Cycles);
                for (int i = 0; i < Cycles ; i++)
                {
                    lst.Add(i);
                }
            });
        }

        static long MeasureArray()
        {
            return MeasureTime(() =>
            {
                var lst = new int[Cycles];
                for (int i = 0; i < Cycles ; i++)
                {
                    lst[i] = i;
                }
            });
        }

        static long MeasureGenericList()
        {
            return MeasureTime(() =>
            {
                var lst = new List<int>(Cycles);
                for (int i = 0; i < Cycles ; i++)
                {
                    lst.Add(i);
                }
            });
        }


        static long MeasureTime(Action action)
        {
            var sw = new Stopwatch();
            sw.Start();

            action();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
