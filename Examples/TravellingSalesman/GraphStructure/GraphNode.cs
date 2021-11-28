using System;
using System.Collections.Generic;
using System.Text;

namespace MiniGAFramework.Examples.TravellingSalesman.GraphStructure
{
    public class GraphNode
    {
        private int id;

        public GraphNode(int id)
        {
            this.id = id;
        }

       public int NodeId {
            get { return this.id; }
            set { this.id = value; }
        }
    }
}
