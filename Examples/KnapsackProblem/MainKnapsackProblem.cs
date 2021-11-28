using System;
using MiniGAFramework.Examples.KnapsackProblem;
using System.IO;
using System.Collections.Generic;

namespace MiniGAFramework {
    
    public class MainKnapsackProblem {

        KnapsackGA Algorithm { get; set; }
        
        
        // Provides the necessary setup to run the solution.
        public MainKnapsackProblem() {
            Algorithm = new KnapsackGA(6404180);
            LoadItems();
            Algorithm.MaxGenerations = 50;
            Algorithm.MutationTax = 0.1f;
            Algorithm.PopulationSize = 10;
            Algorithm.EliteSelection = false;

        }

        // Run several instances of the Knapsack Genetic algorithm in order to get the mean of the results. 
        // The final mean will be saved into a output file.
        public void ExecuteMeanResult(int amount) {
            Dictionary<int, List<Individual>> results = new Dictionary<int, List<Individual>>();
            double[] mean;

            for (int i = 0; i < amount; i++) {
                Algorithm.Run();
                results.Add(i, Algorithm.BetterSelections);
            }

            mean = new double[Algorithm.MaxGenerations];
            for (int i = 0; i < Algorithm.MaxGenerations; i++)
                mean[i] = 0;

            for (int i = 0; i < Algorithm.MaxGenerations; i++) {
                foreach (KeyValuePair<int, List<Individual>> key in results) {
                    mean[i] += key.Value[i].Fitness;
                }
            }

            for (int i = 0; i < mean.Length; i++) {
                mean[i] /= 100;
                Console.WriteLine(mean[i]);
            }


            StreamWriter writer = new StreamWriter("MeanResult.txt");
            for (int i = 0; i < mean.Length; i++)
                writer.WriteLine(mean[i]);
            writer.Close();
            Console.WriteLine("Result saved to file MeanResult.txt");
        }
        
        // Execute the Knapsack Genetic algorithm only once and save the better selections to an output file.
        public void Execute() {
            Algorithm.Run();
            Algorithm.PrintBestSelections("Output.txt");
        }
        
        // Loads the items available for the knapsack bag according to the defined input. In this instance, we use two files - Weight.txt and Utility.txt - to define the items that should be carried.
        // Use only as reference.
        private void LoadItems() {
            List<int> weights = new List<int>();
            List<int> utilities = new List<int>();
            StreamReader file = new StreamReader(@"InputBag/Weight.txt");
            string textLine = String.Empty;
            while (!file.EndOfStream) {
                textLine = file.ReadLine();
                weights.Add(Int32.Parse(textLine));
            }

            file.Close();

            file = new StreamReader(@"InputBag/Utility.txt");
            while (!file.EndOfStream) {
                textLine = file.ReadLine();
                utilities.Add(Int32.Parse(textLine));
            }
            file.Close();

            Algorithm.QuantityItems = weights.Count;
            
            for (int i = 0; i < weights.Count; i++) {
                KnapsackGA.ItemList[i] = new KnapsakItem(i, utilities[i], weights[i]);
            }
        }
    }
}
