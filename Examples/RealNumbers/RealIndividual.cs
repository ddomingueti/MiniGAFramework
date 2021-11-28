using System;
using System.Collections.Generic;
using System.Text;

namespace MiniGAFramework.Examples.RealNumbers {
    public class RealIndividual : Individual {

        public double[] Elements { get; set; }

        public RealIndividual(int dimension, bool createRandom) : base(dimension) {
            Elements = new double[dimension];
            for (int i = 0; i< dimension; i++) {
                if (createRandom)
                    Elements[i] = RealNumbersGA.random.Next(RealNumbersGA.MinRandomValue, RealNumbersGA.MaxRandomValue);
                else
                    Elements[i] = 0;
            }
            EvaluateFitness();
        }

        public override void EvaluateFitness() {
            double sum = 0;
            for (int i = 0; i < Dimension; i++) {
                sum += Elements[i] * Elements[i];
            }
            Fitness = Math.Sqrt(1/sum);
        }

        public override void Mutate() {
            Random randomElement = new Random();
            int position = randomElement.Next(0, Dimension);
            Elements[position] = randomElement.Next(RealNumbersGA.MinRandomValue, RealNumbersGA.MaxRandomValue);
            EvaluateFitness();
        }

        public override string ToString() {
            string ret = String.Empty;
            for (int i=0; i < Dimension; i++) {
                ret += Elements[i] + "; ";
            }
            ret += Fitness + ";";
            return ret;
        }
    }
}
