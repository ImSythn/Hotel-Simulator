using System.Collections.Generic;
using System.Linq;
using System.Drawing;
namespace Hotel_Simulator
{
    public class HotelGraph
    {
        public List<HotelNode> HotelNodeSet { get; set; }
        public int HotelMaxHeight { get; set; }

        public HotelGraph()
        {
            HotelNodeSet = new List<HotelNode>();
        }

        public void GenerateGraph(List<RoomObject> roomSpecificationList)
        {
            HotelMaxHeight = roomSpecificationList.Max(rs => rs.Position.Y) + 1; // hotel height +1 for zero conpensation.
            foreach (RoomObject roomSpecification in roomSpecificationList)
            {
                    HotelNodeSet.Add(new HotelNode(roomSpecification, HotelMaxHeight));
            }
        }
        public void AddHotelEdge()
        {
            HotelNodeSet = HotelNodeSet.OrderBy(n => n.RoomData.Position.Y).ThenBy(n => n.RoomData.Position.X).ToList(); // Orders the list so edges can be added easily.

            for (int index = 0; index < HotelNodeSet.Count; index++) // For each HotelNode add edges.
            {
                HotelNode hotelNode = HotelNodeSet[index];
                if (index < HotelNodeSet.Count - HotelNodeSet[index].RoomData.Dimension.X) // Checks if HotelNodeSet is not out of range.
                {
                    HotelNode neighbourHotelNode = HotelNodeSet[index + 1]; // Finds the next node in the orded HotelNodeSet list.
                    
                    if (neighbourHotelNode.RoomData.Position.Y == hotelNode.RoomData.Position.Y) // Adds all horizontal neighbours for the rooms.
                    {
                        hotelNode.RoomNeighbour.Add(new HotelEdge(hotelNode, neighbourHotelNode));
                        neighbourHotelNode.RoomNeighbour.Add(new HotelEdge(neighbourHotelNode, hotelNode));
                    }
                    if (hotelNode.RoomData.AreaType.Equals("Stairwell") || hotelNode.RoomData.AreaType.Equals("Elevator")) // Adds all upper and lower neighbours for the starwell/elevator.
                    {
                        HotelNode ElevatorNeighbours = HotelNodeSet.FirstOrDefault(n => n.RoomData.Position.Y.Equals(HotelNodeSet[index].RoomData.Position.Y+1) && n.RoomData.Position.X.Equals(HotelNodeSet[index].RoomData.Position.X)); // Finds the next Elevator/Stair neightbour in the orded HotelNodeSet list.
                        if (ElevatorNeighbours != null)
                        {
                            hotelNode.RoomNeighbour.Add(new HotelEdge(hotelNode, ElevatorNeighbours));
                            ElevatorNeighbours.RoomNeighbour.Add(new HotelEdge(ElevatorNeighbours, hotelNode));
                        }
                    }
                }
            }
        }
    }
}
