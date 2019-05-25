using HotelEvents;
namespace Hotel_Simulator
{
    public interface IHuman
    {
        Room MyRoom { get; set; }
        void Move();
        void RoomEventFinder(HotelNode GoToNode, HotelEvent evt);
    }
}
