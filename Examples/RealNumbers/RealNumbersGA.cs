using System;
using System.Collections.Generic;
using System.IO;

namespace MiniGAFramework.Examples.RealNumbers {
    public class RealNumbersGA : GeneticAlgorithm {
        
        public static int MinRandomValue { get; set; }
        public static int MaxRandomValue { get; set; }
        
        public RealNumbersGA(int size, int generations, float tax, float error) : base(size, generations, tax, error) {
            MinRandomValue = 0;
            MaxRandomValue = 10;
        }

        public RealNumbersGA(int minValue, int maxValue) : base() {
            MinRandomValue = minValue;
            MaxRandomValue = maxValue;
        }

        protected override void CreatePopulation() {
            CurrentPopulation = new List<Individual>();
            for (int i = 0; i<PopulationSize; i++) {
                Individual newInd = new RealIndividual(3, true);
                CurrentPopulation.Add(newInd);
            }
        }

        //Crossover is performed through the mean value
        protected override Individual Crossover(Individual a, Individual b) {
            RealIndividual indA = (RealIndividual)a;
            RealIndividual indB = (RealIndividual)b;

            RealIndividual newInd = new RealIndividual(a.Dimension, false);
            for (int i=0; i<a.Dimension; i++) {
                newInd.Elements[i] = (indA.Elements[i] + indB.Elements[i]) / 2.0f;
            }
            return newInd;
        }

        //Uses the tournament method to select a new parent
        protected override Individual SelectParent() {
            return SelectionMethod.Tournament(CurrentPopulation);
        }
    }
}