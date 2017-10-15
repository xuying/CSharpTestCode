using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            Task t1 = FooAsync("t1");
            Task t2 = FooAsync("t2");
            Task.WaitAll(t1, t2);
            
            sw.Stop();
            Console.WriteLine($"Wait time: {sw.ElapsedMilliseconds}");
        }

        static async Task FooAsync(string s)
        {
            for (int i = 0; i < 200; i++)
            {
                await Task.Delay(i);
                Console.WriteLine($"{s} - {i}");
            }
        }
    }
}
