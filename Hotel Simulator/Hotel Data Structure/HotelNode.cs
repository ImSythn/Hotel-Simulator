using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace Hotel_Simulator
{
    public class HotelNode : PictureBox
    {
        public RoomObject RoomData { get; set; }
        public List<HotelEdge> RoomNeighbour { get; set; }
        public List<IObject> hotelObject;
        public IObject HotelObject // Set Tiles GameObject so it can be used as an object
        {
            get { return hotelObject.First(); }
            set
            {
                hotelObject.Add(value);  // Sets the GameObject IObject so this Tile knows what's on it 
                if (value != null)  // Sets the background image of this Tile so it shows the sprite that IObject is liked to 
                {
                    if(!(value is IHuman))
                    {
                        BackgroundImage = hotelObject.First().Sprite;
                        BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                else
                {
                    BackgroundImage = null;
                    Image = null;
                }
            }
        }
        public HotelNode(RoomObject roomData, int HotelMaxHeight)
        {
            hotelObject = new List<IObject>();
            RoomData = roomData;
            RoomNeighbour = new List<HotelEdge>();
            Size = new Size(RoomData.Dimension.X * 150, RoomData.Dimension.Y * 75);
            Location = new Point(RoomData.Position.X * 150, (HotelMaxHeight - RoomData.Position.Y - RoomData.Dimension.Y) * 75); // (HotelMaxHeight -) to invert y-axis of microsoft forms, (- RoomData.Dimension.Y) for solving taller rooms drawing correctly.
        }
    }
}
