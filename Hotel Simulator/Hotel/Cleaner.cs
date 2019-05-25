using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using HotelEvents;

namespace Hotel_Simulator
{
    public class Cleaner : HumanSchematic
    {
        public Cleaner(HotelNode hotelNode, Dictionary<string, string> Data, List<HotelNode> hotelNodes)
        {
            if (hotelNode != null && hotelNodes != null)
            {
                Sprite = Image.FromFile(@"..\..\Resources\Images\Cleaner.png");
                this.hotelNode = hotelNode;
                this.hotelNodes = hotelNodes;
                this.hotelNode.Image = Sprite;

                leaveHotel = false;
                hotelNodeDestination = FindSpecificOpenRoom(Data, hotelNodes);
                MyRoom = (Room)hotelNodeDestination.HotelObject;
                specificRoomDirections = RoomPathFinder.PathToRoom(hotelNode, hotelNodeDestination, hotelNodes);             // Uses Dijkstra to find the shortest path to a room. (Location of guest, location of destination, hotel graph)

                hotelRoom = (IHotelRoom)hotelNode.HotelObject;                                                               // Casts this hotelNodes object as a IHotelRoom. 
                hotelRoom.AddHuman(this);                                                                                    // Add this instance of a cleaner to a concrete room type. 
            }
        }
        public override HotelNode FindSpecificOpenRoom(Dictionary<string, string> Data, List<HotelNode> hotelNodes)
        {
            int roomClassification = int.Parse(Data.Values.First());                                                         // Cuts out the classification so it's usable. Layout: ("rating in number""space"star(s)). 
            hotelNodeDestination = hotelNodes.FirstOrDefault(n => n.HotelObject is IHotelRoom hotelRoom                      // Room is of type IHotelRoom,
                                                               && n.RoomData.ID.Equals(roomClassification));                 // room is of classification.
            hotelRoomDestination = (IHotelRoom)hotelNodeDestination.HotelObject;
            hotelRoomDestination.Occupied = true;                                                                            // Makes the destination room full.
            return hotelNodeDestination;
        }
    }
}
