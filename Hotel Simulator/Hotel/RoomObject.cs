using System.Drawing;

namespace Hotel_Simulator
{
    public class RoomObject
    {
        public string Classification { get; set; } // class of spsific room.
        public int ID { get; set; }                // Idetification of spesific room. 
        public int Capacity { get; set; }          // capacity of specific room.
        public string AreaType { get; set; }       // Type of specific room.
        public Point Position { get; set; }        // Position of specific room.
        public Point Dimension { get; set; }       // Dimentions of specific room.
    }
}
