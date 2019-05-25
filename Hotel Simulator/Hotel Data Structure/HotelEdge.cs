namespace Hotel_Simulator
{
    public class HotelEdge
    {
        public HotelNode RoomSource { get; set; }
        public HotelNode RoomDestination { get; set; }
        public HotelEdge(HotelNode roomSource, HotelNode roomDestination)
        {
            RoomSource = roomSource;
            RoomDestination = roomDestination;
        }
    }
}
