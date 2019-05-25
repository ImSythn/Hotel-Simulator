using System.Collections.Generic;
using System.Drawing;

namespace Hotel_Simulator
{
    public abstract class HotelRoomSchematic : IObject, IHotelRoom  // Creates a rought sketch of how a room has to look like
    {
        public Image Sprite { get; set; }
        public Image spriteOccupied;
        public bool Occupied { get; set; }
        public List<IHuman> HumanList { get; set; }
        public HotelNode hotelNode;
        
        public virtual void AddHuman(IHuman human)
        {
            HumanList.Add(human);                          // Adds a human to a human list each room has.
        }

        public void RemoveHuman(IHuman human)
        {
            HumanList.Remove(human);                       // Removes a human to a human list each room has.
        }
    }
}
