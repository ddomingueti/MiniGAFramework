using System;
using System.Collections.Generic;
using System.Text;

namespace MiniGAFramework.Examples.KnapsackProblem {
  
    public class KnapsakItem {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Utility { get; set; }

        //Defines an Item available to put in the bag. Each item is defined by a Id number, Weight and a Utility value.
        public KnapsakItem(int id, int utility, int weight) {
            Id = id;
            Utility = utility;
            Weight = weight;
        }

        public override string ToString() {
            return "Id: " + Id + "; Weight: " + Weight + "; Utility: " + Utility;
        }
    }
}
