using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MiniGAFramework {
    public abstract class GeneticAlgorithm {

        public int PopulationSize { get; set; }
        public List<Individual> CurrentPopulation { get; set; }

        public int MaxGenerations { get; set; }
        public double MutationTax { get; set; }
        public double ErrorTax { get; set;}
        public bool EliteSelection { get; set; }

        /// <summary>
        /// Set or get the best individuals of each generation.
        /// </summary>
        public List<Individual> BetterSelections { get; set; }
        /// <summary>
        /// Print on screen the current algorithm state for debug purposes
        /// </summary>
        protected bool Debug { get; set; }
        /// <summary>
        /// Gets the number of the current generation
        /// </summary>
        protected int currentGeneration;
        protected List<Individual> newPopulation;
        public static Random random;

        public GeneticAlgorithm() {
            random = new Random();
        }

        public GeneticAlgorithm(int populationSize, int maxGenerations, double mutationTax, double errorTax) {
            PopulationSize = populationSize;
            MaxGenerations = maxGenerations;
            MutationTax = mutationTax;
            ErrorTax = errorTax;
            currentGeneration = 0;
            EliteSelection = false;
            random = new Random();
            Debug = false;
        }
        
        public virtual void Run() {
            //Setup
            CreatePopulation();
            BetterSelections = new List<Individual>();
            currentGeneration = 0;
            
            // Main G.A. execution loop
            while (true) {
                newPopulation = new List<Individual>();
                if ((currentGeneration > 0) && EliteSelection) {
                    newPopulation.Add(BetterSelections[currentGeneration - 1]);
                }
                
                for (int i = 0; i < PopulationSize; i++) {
                    Individual a = SelectParent();
                    Individual b = SelectParent();
                    Individual newIndividual = Crossover(a, b);
                    if (random.NextDouble() > MutationTax)
                        newIndividual.Mutate();
                    newPopulation.Add(newIndividual);
                }

                if (Debug) {
                    Console.WriteLine(newPopulation.Count);
                    foreach (Individual ind in newPopulation)
                        Console.WriteLine(ind.ToString());
                }
                
                GetBestIndividual(newPopulation);

                CurrentPopulation.Clear();
                CurrentPopulation = newPopulation;
                bool test = Evaluate(CurrentPopulation);
                if (currentGeneration >= MaxGenerations - 1) {
                    break;
                }

                currentGeneration++;
                if (Debug) {
                    Console.WriteLine("----- Current Better -----");
                    foreach (Individual ind in BetterSelections) {
                        Console.WriteLine(ind.ToString());
                    }

                    Console.WriteLine("----- Current Population -----");
                    foreach (Individual ind in CurrentPopulation) {
                        Console.WriteLine(ind.ToString());
                    }
                }
            }

            foreach (Individual ind in BetterSelections)
                Console.WriteLine(ind.ToString());
        }
        /// <summary>
        /// Defines how a population will be evaluated - whether is feasible to continue the proccess
        /// </summary>
        /// <param name="population"></param>
        /// <returns></returns>
        protected virtual bool Evaluate(List<Individual> population) {
            if (population[0].Fitness < ErrorTax)
                return true;
            return false;
        }
        /// <summary>
        /// Finds and add the best individual of the current population to a list
        /// </summary>
        /// <param name="population"></param>
        protected virtual void GetBestIndividual(List<Individual> population) {
            population.Sort();
            BetterSelections.Add(population[0]);
        }
        /// <summary>
        /// Defines how the population will be created according to the problem.
        /// </summary>
        protected abstract void CreatePopulation();
        /// <summary>
        /// Defines the way a parent individual is selected to perform the crossover proccess
        /// </summary>
        /// <returns></returns>
        protected abstract Individual SelectParent();
        /// <summary>
        /// Provides the Crossover process. As result, it returns a new individual from two selected parents.
        /// </summary>
        /// <param name="a">New parent 'A'</param>
        /// <param name="b">New parent 'B'</param>
        /// <returns>New Individual</returns>
        protected abstract Individual Crossover(Individual a, Individual b);
        /// <summary>
        /// Print the list of the best generated individuals to a file.
        /// </summary>
        /// <param name="fileName"></param>
        public virtual void PrintBestSelections(string fileName) {
            string saveString = String.Empty;
            foreach (Individual ind in BetterSelections)
                saveString += ind.ToString() + "\n";
            File.WriteAllText(fileName, saveString);

        }
    }
}
