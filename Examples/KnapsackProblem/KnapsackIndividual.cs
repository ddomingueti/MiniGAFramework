using MiniGAFramework;
using System.Collections.Generic;
using System;

namespace MiniGAFramework.Examples.KnapsackProblem {

    public class KnapsackIndividual : Individual, IComparable<KnapsackIndividual> {
        
        public int CurrentWeight { get; set; }
        public int[] Items { get; set; }
        public KnapsackIndividual(int dimension) : base (dimension) {
            Items = new int[dimension];
        }

        public KnapsackIndividual(int dimension, bool generateRandom) : base(dimension) {
            Items = new int[Dimension];
            for (int i = 0; i < Dimension; i++) {
                if (generateRandom) {
                    Items[i] = KnapsackGA.random.Next(0, 2);
                    EvaluateFitness();
                    if (Fitness > KnapsackGA.MaxWeight)
                        Items[i] = 0;
                } else {
                    Items[i] = 0;
                }
            }
        }

        public override void EvaluateFitness() {
            Fitness = 0;
            CurrentWeight = 0;
            for (int i=0; i<Dimension; i++) {
                if (Items[i] > 0) {
                    CurrentWeight += KnapsackGA.ItemList[i].Weight;
                    Fitness += KnapsackGA.ItemList[i].Utility;
                }
            }
        }

        public override void Mutate() {
            int id = KnapsackGA.random.Next(0, Dimension);
            if (Items[id] == 0)
                Items[id] = 1;
            else
                Items[id] = 0;

            EvaluateFitness();
        }

        public override string ToString() {
            string ret = string.Empty;
            for (int i=0; i<Dimension; i++) {
                ret += Items[i] + "; ";
            }
            return "Fitness: " + Fitness + "; Weight: " + CurrentWeight;
        }

        public int CompareTo(KnapsackIndividual other) {
            if (Fitness < other.Fitness) 
                return -1;
            else if (Fitness == other.Fitness) 
                return 0;
            else 
                return 1;
        }
    }
}