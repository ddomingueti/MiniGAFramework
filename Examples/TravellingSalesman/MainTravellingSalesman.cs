using System;
using MiniGAFramework;
using MiniGAFramework.Examples.TravellingSalesman.GraphStructure;

namespace MiniGAFramework.Examples.TravellingSalesman
{
    public class MainTravellingSalesman {

        GATravellingSalesman Algorithm { get; set; }

        public MainTravellingSalesman() {
            GATravellingSalesman Algorithm = new GATravellingSalesman();
            GATravellingSalesman.EntryGraph = new Graph(5);
            Algorithm.PopulationSize = 10;
            Algorithm.MutationTax = 0.05f;
            Algorithm.EliteSelection = true;
            Algorithm.MaxGenerations = 3;
        }

        public void LoadData() {
            GATravellingSalesman.EntryGraph.SetUnindirectedEdge(0, 1, 2);
            GATravellingSalesman.EntryGraph.SetUnindirectedEdge(0, 2, 4);
            GATravellingSalesman.EntryGraph.SetUnindirectedEdge(0, 3, 1);
            GATravellingSalesman.EntryGraph.SetUnindirectedEdge(0, 4, 5);
            GATravellingSalesman.EntryGraph.SetUnindirectedEdge(1, 0, 9);
            GATravellingSalesman.EntryGraph.SetUnindirectedEdge(1, 2, 10);
            GATravellingSalesman.EntryGraph.SetUnindirectedEdge(1, 3, 2);
            GATravellingSalesman.EntryGraph.SetUnindirectedEdge(1, 4, 1);
            GATravellingSalesman.EntryGraph.SetUnindirectedEdge(3, 0, 5);
            GATravellingSalesman.EntryGraph.SetUnindirectedEdge(3, 1, 3);
            GATravellingSalesman.EntryGraph.SetUnindirectedEdge(3, 2, 4);
            GATravellingSalesman.EntryGraph.SetUnindirectedEdge(3, 4, 8);
        }

        public void Execute() {
            Algorithm.Run();
            Algorithm.PrintBestSelections("OutputSalesman.txt");
        }
    }
}
