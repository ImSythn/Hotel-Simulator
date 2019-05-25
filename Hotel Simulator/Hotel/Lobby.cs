using System.Collections.Generic;
using System.Drawing;

namespace Hotel_Simulator
{
    public class Lobby : HotelRoomSchematic
    {
        public Lobby(HotelNode hotelNode)
        {
            Sprite = Image.FromFile(@"..\..\Resources\Images\Lobby.png");
            this.hotelNode = hotelNode;
            Occupied = false;
            HumanList = new List<IHuman>();
        }
    }
}
