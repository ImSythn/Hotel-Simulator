using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using HotelEvents;

namespace Hotel_Simulator
{
    public class Guest : HumanSchematic
    {

        public Guest(HotelNode hotelNode, Dictionary<string, string> Data, List<HotelNode> hotelNodes)
        {
            if (hotelNode != null && Data != null && hotelNodes != null)
            {
                Sprite = Image.FromFile(@"..\..\Resources\Images\Guest.png");
                this.hotelNode = hotelNode;
                this.hotelNodes = hotelNodes;
                this.hotelNode.Image = Sprite;

                myRoom = (IHotelRoom)hotelNode.HotelObject;
                myRoom.Occupied = true;
                name = Data.Keys.First();

                leaveHotel = false;
                hotelNodeDestination = FindSpecificOpenRoom(Data, hotelNodes);
                MyRoom = (Room)hotelNodeDestination.HotelObject;
                myHotelNode = hotelNodeDestination;
                specificRoomDirections = RoomPathFinder.PathToRoom(hotelNode, hotelNodeDestination, hotelNodes); // Uses Dijkstra to find the shortest path to a room. (Location of guest, location of destination, hotel graph)

                hotelRoom = (IHotelRoom)hotelNode.HotelObject;                                                   // Casts this hotelNodes object as a IHotelRoom. 
                hotelRoom.AddHuman(this);                                                                        // Add this instance of a guest to a concrete room type. 
            }
        }

        public override HotelNode FindSpecificOpenRoom(Dictionary<string, string> Data, List<HotelNode> hotelNodes)
        {
            string roomClassification = Data.Values.First().Substring(8).Insert(1, " ");                                     // Cuts out the classification so it's usable. Layout: ("rating in number""space"star(s)). 
            if (roomClassification.Equals("1 stars"))                                                                        // Replaces roomClassification to usable roomClassification in the .Json.
                roomClassification = "1 Star";
            hotelNodeDestination = hotelNodes.FirstOrDefault(n => n.RoomData.Classification != null                          // Finds first room where:
                                                               && n.HotelObject is IHotelRoom hotelRoom                      // Room is of type IHotelRoom,
                                                               && hotelRoom.Occupied == false                                // room is not full and
                                                               && n.RoomData.Classification.Equals(roomClassification));     // room is of classification.
            hotelRoomDestination = (IHotelRoom)hotelNodeDestination.HotelObject;
            hotelRoomDestination.Occupied = true;                                                                            // Makes the destination room full.
            return hotelNodeDestination;
        }
    }
}
