using System.Collections.Generic;
using System;

namespace MiniGAFramework.Examples.KnapsackProblem {

    public class KnapsackGA : GeneticAlgorithm {

        public static int MaxWeight { get; set; }
        public static KnapsakItem[] ItemList { get; set; }

        public int QuantityItems { get; set; }
        private double globalSum = -1;

        public KnapsackGA(int maxWeight) : base() {
            MaxWeight = maxWeight;
            Debug = false;
            CurrentPopulation = new List<Individual>();
        }

        public override void Run() {
            base.Run();
            PrintPopulation(CurrentPopulation);
        }

        protected override void CreatePopulation() {
            CurrentPopulation = new List<Individual>();
            for (int i = 0; i < PopulationSize; i++) {
                CurrentPopulation.Add(new KnapsackIndividual(QuantityItems));
            }
        }

        protected override bool Evaluate(List<Individual> population) {
            bool ret = true;
            int overflow = 0;
            foreach (Individual ind in population) {
                KnapsackIndividual indPopulation = (KnapsackIndividual)ind;
                globalSum += indPopulation.Fitness;
                overflow = MaxWeight - indPopulation.CurrentWeight;
                if (overflow < 0) {
                    indPopulation.Fitness += overflow / MaxWeight;
                    ret = false;
                }
            }
            return ret;
        }

        protected override Individual Crossover(Individual a, Individual b) {
            int crossoverPoint = random.Next(0, QuantityItems);
            KnapsackIndividual indA = (KnapsackIndividual)a;
            KnapsackIndividual indB = (KnapsackIndividual)b;
            KnapsackIndividual newItem = new KnapsackIndividual(QuantityItems, false);
            for (int i = 0; i < crossoverPoint; i++)
                newItem.Items[i] = indA.Items[i];

            for (int i = crossoverPoint; i < QuantityItems; i++)
                newItem.Items[i] = indB.Items[i];
            newItem.EvaluateFitness();
            return newItem;
        }

        protected override Individual SelectParent() {
            Evaluate(CurrentPopulation);
            return SelectionMethod.Tournament(CurrentPopulation);
        }

        protected override void GetBestIndividual(List<Individual> population) {
            population.Sort();
            KnapsackIndividual better = new KnapsackIndividual(8, false);
            foreach (Individual ind in population) {
                KnapsackIndividual indM = (KnapsackIndividual)ind;
                if ((indM.CurrentWeight <= MaxWeight) && (indM.Fitness > better.Fitness)) {
                    better = indM;
                }       
            }
            if (better.Fitness > 0)
                BetterSelections.Add(better);
        }

        public void PrintPopulation(List<Individual> population) {
            for (int i=0; i<population.Count; i++) {
                Console.WriteLine(population[i].ToString());
            }
        }
    }

}