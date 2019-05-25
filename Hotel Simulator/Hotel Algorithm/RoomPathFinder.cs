using System.Collections.Generic;
using System.Linq;

namespace Hotel_Simulator
{
    public static class RoomPathFinder
    {
        public static List<HotelNode> PathToRoom(HotelNode source, HotelNode destination, List<HotelNode> graph)
        {
            List<HotelNode> fastestRout = new List<HotelNode>();
            Dictionary<HotelNode, int> distanceToNode = new Dictionary<HotelNode, int>();
            Dictionary<HotelNode, HotelNode> lastNode = new Dictionary<HotelNode, HotelNode>();
            List<HotelNode> queue = new List<HotelNode>();
            graph.ForEach(node => queue.Add(node));

            foreach (HotelNode node in queue)
            {
                distanceToNode.Add(node, int.MaxValue); // The distance to the other vertices is unknown so they get the temporary value of null.
            }
            distanceToNode[source] = 0; // The distance from the source node to the source node is always 0.

            while (queue.Count != 0)
            {
                // Find vertex with smallest distance and remove it from queue.
                HotelNode smallNode = queue.OrderBy(node => distanceToNode[node]).FirstOrDefault();
                queue.Remove(smallNode);

                // For each edge adjacent to smallnode add edge cost to get to neighboring vertex. 
                foreach (HotelEdge edge in smallNode.RoomNeighbour)
                {
                    int distance = distanceToNode[smallNode] + 1;

                    // If edge cost to neighbor is bigger than current distance, overwrite value for the edge.destination, set key to edge.destination and value to smallNode. 
                    if (distance < distanceToNode[edge.RoomDestination])
                    {
                        distanceToNode[edge.RoomDestination] = distance;
                        lastNode[edge.RoomDestination] = smallNode;
                    }
                }
                // If smallNode has reached the destination break.
                if (smallNode == destination)
                    break;
            }

            while (lastNode.ContainsKey(destination))
            {
                fastestRout.Add(destination);
                destination = lastNode[destination];
            }
            // Reverses rout because fastestRout finds the fastest rout backwards.
            fastestRout.Reverse();

            return fastestRout;
        }
    }
}
