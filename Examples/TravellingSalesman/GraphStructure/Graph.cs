using System.Collections.Generic;
using System;

namespace MiniGAFramework.Examples.TravellingSalesman.GraphStructure
{
    public class Graph
    {
        float[,] nodeMatrix;
        int numVertices;

        public Graph(int dimension)
        {
            nodeMatrix = new float[dimension, dimension];
            numVertices = dimension;
            for (int i = 0; i < dimension; i++)
                for (int j = 0; j < dimension; j++)
                    nodeMatrix[i, j] = 0;
        }

        public float[,] NodeMatrix {
            get { return this.nodeMatrix; }
            set { this.nodeMatrix = value; }
        }

        public float GetValue(int i, int j) {
            return nodeMatrix[i, j];
        }

        public void SetUnindirectedEdge(int from, int to, float coast)
        {
            nodeMatrix[from, to] = coast;
            nodeMatrix[to, from] = coast;
        }

        public void SetDirectedEdge(int from, int to, float coast)
        {
            nodeMatrix[from, to] = coast;
        }

        public int Count {
            get { return numVertices; }
        }

        public override string ToString()
        {
            string ret = String.Empty;
            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    ret += nodeMatrix[i, j] + " ";
                }
                ret += "\n";
            }
            return ret;
        }
    }
}
