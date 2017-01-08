using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using LazyLoading;

namespace LazyLoadingTests
{
    [TestClass]
    public class LazyLoadingTests
    {
        [TestMethod]
        public void LazyLoadingCalulator_ExampleInput_ExampleOutput()
        {
            string result = @"ExampleData\lazy_loading_example_computedOutput.txt";
            string expectedOutput = @"ExampleData\lazy_loading_example_output.txt";

            LazyLoadingCalculator lazyLoader = new LazyLoadingCalculator(@"ExampleData\lazy_loading_example_input.txt"
                                , result);
            lazyLoader.startComputing();

            
            FileAssert.AreEqual(expectedOutput, result);
        }

    }
}
