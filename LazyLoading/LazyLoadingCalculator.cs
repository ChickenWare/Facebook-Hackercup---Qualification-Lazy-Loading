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
        const int minimumApparentWeight = 50;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public LazyLoadingCalculator()
        {
        }
        public void Init(string inputPath, string outputPath)
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
            int linenumber = 1;
            for (int i = 1; i <= numberOfWorkingDays; i++)
            {
                int numberOfItemsForCurrentDay = Convert.ToInt32(reader.ReadLine());
                itemsWeights.Clear();
                linenumber++;

                for (int j = 0; j < numberOfItemsForCurrentDay; j++)
                {
                    linenumber++;
                    itemsWeights.Add(Convert.ToInt32(reader.ReadLine()));
                }

                optimalRoundTripsForCurrentDay = ComputeMaximumRoundTrips(itemsWeights);

                writer.Write(string.Format("Case #{0}: {1}\n", i, optimalRoundTripsForCurrentDay));
            }

            reader.Close();
            writer.Flush();
            writer.Close();
        }

        public int ComputeMaximumRoundTrips(List<int> itemsWeights)
        {
            if (itemsWeights.Count == 1)
                return 1;

            int amountOfTrips = 0;

            itemsWeights.Sort();
            int topItem;
            int numberOfItemsNeededToFakeHeavyLifting = 0;

            while (itemsWeights.Count > 0)
            {
                topItem = itemsWeights.Last();
                itemsWeights.Remove(topItem);
                numberOfItemsNeededToFakeHeavyLifting = (int)Math.Ceiling((double)minimumApparentWeight / (double)topItem);

                if (itemsWeights.Count >= (numberOfItemsNeededToFakeHeavyLifting - 1))
                {
                    itemsWeights.RemoveRange(0, numberOfItemsNeededToFakeHeavyLifting - 1);
                    amountOfTrips++;
                }
                else
                {
                    //There are not enough items to fake the last trip - Asuming they go into other trips 
                    // Discard rest of list
                    itemsWeights.Clear();
                }
            }

            return amountOfTrips;
        }
    }

}