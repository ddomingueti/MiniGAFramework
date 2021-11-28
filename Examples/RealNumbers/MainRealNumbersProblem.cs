using System;
using System.Collections.Generic;
using System.Text;

namespace MiniGAFramework.Examples.RealNumbers {
    public class MainRealNumbersProblem {
        RealNumbersGA Algorithm { get; set; }
        
        //Algorithm setup
        public MainRealNumbersProblem() {
            RealNumbersGA Algorithm = new RealNumbersGA(0, 10);
            Algorithm.PopulationSize = 10;
            Algorithm.MaxGenerations = 50;
            Algorithm.MutationTax = 0.1f;
            Algorithm.ErrorTax = 0.5f;
            Algorithm.EliteSelection = false;
        }

        //Run the algorithm and save the final result
        public void Execute() {
            Algorithm.Run();
            Algorithm.PrintBestSelections("Output.txt");
        }

    }
}
