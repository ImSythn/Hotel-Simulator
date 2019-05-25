using System.Collections.Generic;
using System.Drawing;

namespace Hotel_Simulator
{
    public class Elevator : HotelRoomSchematic
    {
        public Elevator(HotelNode hotelNode)
        {
            Sprite = Image.FromFile(@"..\..\Resources\Images\Elevator.png");
            this.hotelNode = hotelNode;
            Occupied = false;
            HumanList = new List<IHuman>();
        }
    }
}