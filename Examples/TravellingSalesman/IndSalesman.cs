using System;
using System.Collections.Generic;
using System.Text;
using MiniGAFramework;

namespace MiniGAFramework.Examples.TravellingSalesman
{
    public class IndSalesman : Individual
    {

        public IndSalesman(int dimension, bool random) : base(dimension)
        {
            Path = new int[dimension];
            List<int> addedValues = new List<int>();
            for (int i = 0; i < dimension; i++)
                addedValues.Add(i);

            int vert = 0;
            for (int i = 0; i < dimension; i++) {
                Path[i] = 0;
                if (random)
                {
                    vert = GATravellingSalesman.random.Next(0, addedValues.Count);
                    Path[i] = addedValues[vert];
                    addedValues.RemoveAt(vert);
                }
            }
        }

        public override void EvaluateFitness()
        {
            double sum = 0;
            for (int i = 0; i < Dimension-1; i++) {
                sum += GATravellingSalesman.EntryGraph.NodeMatrix[Path[i], Path[i + 1]];
            }
            sum += GATravellingSalesman.EntryGraph.GetValue(Dimension - 1, Path[0]);
            Fitness = sum;
        }

        public override void Mutate()
        {
            int pos1 = GATravellingSalesman.random.Next(0, Dimension);
            int pos2 = GATravellingSalesman.random.Next(0, Dimension);

            int temp = Path[pos2];
            Path[pos2] = Path[pos1];
            Path[pos1] = temp;
        }

        public int[] Path { get; set; }

        public override string ToString()
        {
            string ret = String.Empty;

            for (int i = 0; i < Dimension; i++)
                ret += Path[i] + " ";
            ret += "Fitness: " + Fitness;
            return ret;
        }

        public bool Contain(int element)
        {
            for (int i = 0; i < Path.Length; i++)
                if (Path[i] == element)
                    return true;

            return false;
        }

        public override int CompareTo(Individual other)
        {
            if (this.Fitness > other.Fitness)
                return -1;
            return 1;
        }
    }
}
