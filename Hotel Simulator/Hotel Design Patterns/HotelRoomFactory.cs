using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Simulator
{
    public class HotelRoomFactory  // Creates a spesific concrete class based on the AreaType.
    {
        public IObject HotelRooms(HotelNode hotelNode)
        {
            IObject hotelNodeObject = null;
            if (hotelNode.RoomData.AreaType.Equals("Room"))
                hotelNodeObject = new Room(hotelNode);
            else if (hotelNode.RoomData.AreaType.Equals("Lobby"))
                hotelNodeObject = new Lobby(hotelNode);
            else if (hotelNode.RoomData.AreaType.Equals("Restaurant"))
                hotelNodeObject = new Restaurant(hotelNode);
            else if (hotelNode.RoomData.AreaType.Equals("Elevator"))
                hotelNodeObject = new Elevator(hotelNode);
            else if (hotelNode.RoomData.AreaType.Equals("Stairwell"))
                hotelNodeObject = new Stairwell(hotelNode);
            else if (hotelNode.RoomData.AreaType.Equals("Cinema"))
                hotelNodeObject = new Cinema(hotelNode);
            else if (hotelNode.RoomData.AreaType.Equals("Fitness"))
                hotelNodeObject = new Fitness(hotelNode);
            else
                return null;
            return hotelNodeObject;
        }
    }
}
