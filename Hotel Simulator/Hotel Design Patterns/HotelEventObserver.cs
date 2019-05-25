using HotelEvents;

namespace Hotel_Simulator
{
    public class HotelEventObserver : HotelEventListener
    {
        private HotelEventHandler hotelEventObserver;
        private Hotel hotel;
        public HotelEventObserver(Hotel hotel)
        {
            hotelEventObserver = new HotelEventHandler();
            this.hotel = hotel;
        }
        public void Notify(HotelEvent evt)
        {
            hotelEventObserver.EventHandler(evt, hotel);
        }
    }
}
