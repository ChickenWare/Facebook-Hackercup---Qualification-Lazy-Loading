using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LazyLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Wrong number of parameters");
                Console.ReadLine();
            }

            LazyLoadingCalculator lazyLoader = new LazyLoadingCalculator();
            lazyLoader.Init(args[0], args[1]);
            lazyLoader.startComputing();
        }
    }
}
