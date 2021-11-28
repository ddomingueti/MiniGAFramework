using System.Collections.Generic;
using System;

namespace  MiniGAFramework {
    
    // This class presents two classical methods to select a new individual in a given population.
    public class SelectionMethod {
        
        public static Individual Tournament(List<Individual> population) {
            Random random = new Random();
            int ind1 = random.Next(0, population.Count);
            int ind2 = random.Next(0, population.Count);

            if (population[ind1].Fitness < population[ind2].Fitness)
                return population[ind1];
            else
                return population[ind2];
        }
        
        public static Individual RoulleteWhell(List<Individual> population, double globalSum) {
            Random random = new Random();
            double rValue = random.NextDouble();
            int i = 0;
            double sum = 0;
            do {
                i++;
                sum = sum + population[i].Fitness / globalSum;
            } while ((i < population.Count - 1) && (sum < rValue));
            return population[i];
        }
    }   
}