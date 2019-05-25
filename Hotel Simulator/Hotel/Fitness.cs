using System.Collections.Generic;
using System.Drawing;

namespace Hotel_Simulator
{
    public class Fitness : HotelRoomSchematic
    {
        public Fitness(HotelNode hotelNode)
        {
            Sprite = Image.FromFile(@"..\..\Resources\Images\Fitness.png");
            this.hotelNode = hotelNode;
            Occupied = false;
            HumanList = new List<IHuman>();
        }
    }
}
