using System.Collections.Generic;
using System.Drawing;

namespace Hotel_Simulator
{
    public class Stairwell : HotelRoomSchematic
    {
        public Stairwell(HotelNode hotelNode)
        {
            Sprite = Image.FromFile(@"..\..\Resources\Images\Stairs.png");
            this.hotelNode = hotelNode;
            Occupied = false;
            HumanList = new List<IHuman>();
        }
    }
}
