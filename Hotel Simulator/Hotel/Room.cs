using System.Collections.Generic;
using System.Drawing;

namespace Hotel_Simulator
{
    public class Room : HotelRoomSchematic
    {
        public Room(HotelNode hotelNode)
        {
            Sprite = Image.FromFile(@"..\..\Resources\Images\Room.png");
            spriteOccupied = Image.FromFile(@"..\..\Resources\Images\Room occupied.png");
            this.hotelNode = hotelNode;
            Occupied = false;
            HumanList = new List<IHuman>();
        }

        public override void AddHuman(IHuman human)
        {
            HumanList.Add(human);
            if (human.MyRoom == this)                                                       // If the specified room the human is walking to is equal to the this room change the room to an occupied room. 
                hotelNode.BackgroundImage = spriteOccupied;                          
        }
    }
}
