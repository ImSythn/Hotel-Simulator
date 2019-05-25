using System.Collections.Generic;
using System.Drawing;

namespace Hotel_Simulator
{
    public class Cinema : HotelRoomSchematic
    {
        public Cinema(HotelNode hotelNode)
        {
            Sprite = Image.FromFile(@"..\..\Resources\Images\Cinema.png");
            this.hotelNode = hotelNode;
            Occupied = false;
            HumanList = new List<IHuman>();
        }
    }
}
