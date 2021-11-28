using System;
using System.Collections.Generic;
using System.Text;
using MiniGAFramework;
using MiniGAFramework.Examples.TravellingSalesman.GraphStructure;

namespace MiniGAFramework.Examples.TravellingSalesman
{
    public class GATravellingSalesman : GeneticAlgorithm
    {
        public static Graph EntryGraph;

        protected override void CreatePopulation() {
            CurrentPopulation = new List<Individual>();
            for (int i = 0; i<PopulationSize; i++) {
                IndSalesman ind = new IndSalesman(EntryGraph.Count, true);
                CurrentPopulation.Add(ind);
            }
        }

        protected override Individual Crossover(Individual a, Individual b) {
            IndSalesman indS1 = (IndSalesman)a;
            IndSalesman indS2 = (IndSalesman)b;

            int p1 = GATravellingSalesman.random.Next(0, indS1.Dimension);
            int p2 = GATravellingSalesman.random.Next(p1, indS1.Dimension);
            IndSalesman newInd = new IndSalesman(indS1.Dimension, false);
            List<int> addedValues = new List<int>();
            for (int i = 0; i < newInd.Dimension; i++)
                addedValues.Add(i);

            for (int i = p1; i < p2; i++)
            {
                newInd.Path[i] = indS1.Path[i];
                addedValues.Remove(indS1.Path[i]);
            }

            for (int i = 0; i <p1; i++)
            {
                newInd.Path[i] = addedValues[0];
                addedValues.RemoveAt(0);
            }
                
            for (int i = p2;  i < newInd.Dimension; i++)
            {
                newInd.Path[i] = addedValues[0];
                addedValues.RemoveAt(0);
            }

            newInd.EvaluateFitness();
            return newInd;
        }


        protected override Individual SelectParent() {
            return SelectionMethod.Tournament(CurrentPopulation);
        }
    }
}