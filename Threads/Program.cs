using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        const string TABLE_NAME = "asdasd";

        static void Main(string[] args)
        {
            var list = new List<int>().AsParallel().Select(c => c);
            foreach (var item in list)
                Console.WriteLine(item);

            var sql = @"SELECT *
                        FROM {0};";
            var result = String.Format(sql, TABLE_NAME);

            var sw = new Stopwatch();
            sw.Start();
            Parallel.For(0, 10, (i) => Console.WriteLine(i));
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            Console.ReadLine();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);


        }
    }
}
