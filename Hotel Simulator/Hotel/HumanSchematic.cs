using HotelEvents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Simulator
{
    public abstract class HumanSchematic : IObject, IHuman
    {
        public Image Sprite { get; set; }
        public Room MyRoom { get; set; }
        public string name;
        public IHotelRoom myRoom;
        public IHotelRoom hotelRoom;
        public IHotelRoom hotelRoomDestination;
        public HotelNode myHotelNode;
        public HotelNode hotelNode;
        public HotelNode hotelNodeDestination { get; set; }
        public List<HotelNode> specificRoomDirections;
        public List<HotelNode> hotelNodes;
        public bool leaveHotel;

        public abstract HotelNode FindSpecificOpenRoom(Dictionary<string, string> Data, List<HotelNode> hotelNodes);

        public void Move()
        {
            if (leaveHotel == true && hotelRoom == hotelRoomDestination)
            {
                hotelRoom.RemoveHuman(this);
                if (hotelRoom.HumanList.Count == 0)
                    hotelNode.Image = null;
            }
            if (specificRoomDirections.Count > 0)
            {
                HotelNode NextHotelNode = specificRoomDirections.FirstOrDefault(n => hotelNode.RoomNeighbour.Any(e => e.RoomDestination == n)); // Finds the neighbouring hotelnode that equals the first HotelNode in the specificRoomDirections List.
                hotelRoom.RemoveHuman(this);
                
                if (hotelRoom.HumanList.Any(h => h is Guest))
                    hotelNode.Image = Image.FromFile(@"..\..\Resources\Images\Guest.png");
                else
                    hotelNode.Image = Image.FromFile(@"..\..\Resources\Images\Cleaner.png");
                if (hotelRoom.HumanList.Count == 0)                                                                                             // Checks if this hotelRooms HumanList has any humans in it.       
                    hotelNode.Image = null;                                                                                                     // Sets this hotelNodes image to null.
                hotelRoom = (IHotelRoom)NextHotelNode.HotelObject;                                                                              // Casts the NextHotelNodes object to this humans hotelRoom.
                hotelRoom.AddHuman(this);
                NextHotelNode.Image = Sprite;
                if (hotelRoom.HumanList.Any(h => h is Guest) && hotelRoom.HumanList.Any(h => h is Cleaner))
                    NextHotelNode.Image = Image.FromFile(@"..\..\Resources\Images\CombinedCleanerGuest.png");

                specificRoomDirections.Remove(NextHotelNode);                                                                                   // Removes the NextHotelNode from the specificRoomDirections list so next move instructions will be of the next HotelNode in the list.
                hotelNode = NextHotelNode;
            }
            else
                hotelNode.Image = null;                                                                                                         // When Cleaner reached Destination image disapears as if going into their room.
        }
        public void RoomEventFinder(HotelNode GoToNode, HotelEvent evt)
        {
            if (evt.EventType.Equals(HotelEventType.CHECK_OUT) || evt.EventType.Equals(HotelEventType.EVACUATE))                                // Checks if this events has to leave the hotel and make the rooms not full.
            {
                hotelRoom.Occupied = false;
                leaveHotel = true;
                MyRoom.hotelNode.BackgroundImage = Image.FromFile(@"..\..\Resources\Images\Room.png");
            }
            hotelRoomDestination = (IHotelRoom)GoToNode.HotelObject;
            specificRoomDirections = RoomPathFinder.PathToRoom(hotelNode, GoToNode, hotelNodes);                                                // Uses Dijkstra to find the shortest path to a room. (Location of Human, location of destination, hotel graph)
        }
    }
}
