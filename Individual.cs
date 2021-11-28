using System;

namespace MiniGAFramework  {
    // 
    public abstract class Individual : IComparable<Individual> {
        /// <summary>
        /// Standard individual class with a basic set of properties and methods.
        /// </summary>
        /// <param name="dimension"></param>
        public Individual(int dimension) {
            this.Dimension = dimension;
        }
        
        public int Dimension { get; set; }
        
        public double Fitness {get; set;}

        public override string ToString() {
            return "Dimension: " + this.Dimension;
        }

        public abstract void EvaluateFitness();
        public abstract void Mutate();

        public virtual int CompareTo(Individual other) {
            if (this.Fitness < other.Fitness)
                return -1;
            return 1;
        }
    }
}
