using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    class Dijkstra
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
            };

            Dijkstra dijkstra = new Dijkstra();

            dijkstra.FindPath(graph, 4);
            Console.ReadKey();
        }
    

    
    
        //num of vectors
        static readonly int V = 9;

        int MinDistance(bool[] vectorDone, int[] distance)
        {
            int minimum = int.MaxValue, minIndex = -1;

            for (int i = 0; i < V; i++)
            {
                if (vectorDone[i] == false && distance[i] <= minimum)
                {
                    minimum = distance[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        void FindPath(int[,] graph, int src)
        {
            int[] distance = new int[V]; // The output array. dist[i] 
                                     // will hold the shortest 
                                     // distance from src to i 

            // sptSet[i] will true if vertex 
            // i is included in shortest path 
            // tree or shortest distance from 
            // src to i is finalized 
            bool[] vectorDone = new bool[V];

            // Initialize all distances as 
            // INFINITE and stpSet[] as false 
            for (int i = 0; i < V; i++)
            {
                distance[i] = int.MaxValue;
                vectorDone[i] = false;
            }

            // Distance of source vertex 
            // from itself is always 0 
            distance[src] = 0;

            // Find shortest path for all vertices 
            for (int i = 0; i < V - 1; i++)
            {
                // Pick the minimum distance vertex 
                // from the set of vertices not yet 
                // processed.
                int u = MinDistance(vectorDone, distance);

                vectorDone[u] = true;

                for (int j = 0; j < V; j++)
                {
                    // Update distance[j] only if is not in vectorDone, there is an edge from 
                    // u to j, and total weight of path from src to  j through u is 
                    // smaller than current value of distance[v] 
                    if (vectorDone[j] == false && graph[u, j] != 0 && distance[u] != int.MaxValue && distance[u] + graph[u, j] < distance[j])
                    {
                        distance[j] = distance[u] + graph[u, j];
                    }
                }
            }

            PrintSolution(distance);
        }

        // A utility function to print 
        // the constructed distance array 
        void PrintSolution(int[] dist)
        {
            Console.Write("Vertex \t\t Distance "
                          + "from Source\n");
            for (int i = 0; i < V; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }
    }
}
