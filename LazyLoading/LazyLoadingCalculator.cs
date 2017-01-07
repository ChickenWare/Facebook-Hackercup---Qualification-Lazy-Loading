using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LazyLoading
{
    public class LazyLoadingCalculator
    {
        string inputPath;
        string outputPath;

        public LazyLoadingCalculator(string inputPath, string outputPath)
        {
            this.inputPath = inputPath;
            this.outputPath = outputPath;
        }

        public void startComputing()
        {
            ReadInputFileAndWriteAnswerToFile();
        }

        private void ReadInputFileAndWriteAnswerToFile()
        {
            StreamReader reader = new StreamReader(inputPath);
            StreamWriter writer = new StreamWriter(outputPath);

            int numberOfWorkingDays = Convert.ToInt32(reader.ReadLine());
            int optimalRoundTripsForCurrentDay = 0;

            List<int> itemsWeights = new List<int>();

            for (int i = 1; i <= numberOfWorkingDays; i++)
            {
                int numberOfItemsForCurrentDay = Convert.ToInt32(reader.ReadLine());
                itemsWeights.Clear();

                for (int j = 0; j < numberOfItemsForCurrentDay; j++)
                {
                    itemsWeights.Add(Convert.ToInt32(reader.ReadLine()));
                }

                optimalRoundTripsForCurrentDay = ComputeMaximumRoundTrips(itemsWeights);

                writer.Write(string.Format("Case #{0}: {1}", i, optimalRoundTripsForCurrentDay));
            }

            reader.Close();
            writer.Flush();
            writer.Close();
        }

        public int ComputeMaximumRoundTrips(List<int> itemsWeights)
        {
            int amountOfTrips = 0;
            
            itemsWeights.Sort();

            return amountOfTrips;
        }
    }
}
