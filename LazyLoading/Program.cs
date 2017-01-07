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
                throw new ArgumentException("Invalid number of input arguments");
            }
            LazyLoadingCalculator lazyLoader = new LazyLoadingCalculator(args[0],args[1]);
            lazyLoader.startComputing();
        }

        
    }
}
