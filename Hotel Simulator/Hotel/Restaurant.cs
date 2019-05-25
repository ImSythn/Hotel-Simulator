using System.Collections.Generic;
using System.Drawing;

namespace Hotel_Simulator
{
    public class Restaurant : HotelRoomSchematic
    {
        public Restaurant(HotelNode hotelNode)
        {
            Sprite = Image.FromFile(@"..\..\Resources\Images\Restaurant.png");
            this.hotelNode = hotelNode;
            Occupied = false;
            HumanList = new List<IHuman>();
        }
    }
}
