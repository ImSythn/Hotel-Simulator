using HotelEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Simulator
{
    public class HotelEventHandler  // Handles the incomming events from the HotelEvents.dll
    {
        public void EventHandler(HotelEvent evt, Hotel hotel)
        {
            HumanSchematic ThisGuest = new Guest(null, null, null);
            if (evt.Data != null)
            {
                string guestName = evt.Data.Keys.First() + evt.Data.Values.First();
                ThisGuest = (Guest)hotel.humanList.FirstOrDefault(g => g is Guest guest && guest.name.Equals(guestName));
            }
            switch (evt.EventType)
            {
                case HotelEventType.CHECK_IN:
                    HumanSchematic newGuest = new Guest(hotel.lobbyNode, evt.Data, hotel.hotelGraph.HotelNodeSet);
                    hotel.lobbyNode.HotelObject = newGuest;
                    hotel.humanList.Add(newGuest);
                    break;
                case HotelEventType.CHECK_OUT:
                    ThisGuest.RoomEventFinder(hotel.lobbyNode, evt);
                    break;
                case HotelEventType.CLEANING_EMERGENCY:
                    HumanSchematic newCleaner = new Cleaner(hotel.lobbyNode, evt.Data, hotel.hotelGraph.HotelNodeSet);
                    hotel.lobbyNode.HotelObject = newCleaner;
                    hotel.humanList.Add(newCleaner);
                    break;
                case HotelEventType.EVACUATE:
                    foreach (IHuman human in hotel.humanList)
                    {
                        human.RoomEventFinder(hotel.lobbyNode, evt);
                    }
                    break;
                case HotelEventType.GODZILLA:
                    break;
                case HotelEventType.GOTO_CINEMA:
                    ThisGuest.RoomEventFinder(hotel.hotelGraph.HotelNodeSet.FirstOrDefault(n => n.RoomData.AreaType.Equals("Cinema")), evt);
                    break;
                case HotelEventType.GOTO_FITNESS:
                    ThisGuest.RoomEventFinder(hotel.hotelGraph.HotelNodeSet.FirstOrDefault(n => n.RoomData.AreaType.Equals("Fitness")), evt);
                    break;
                case HotelEventType.NEED_FOOD:
                    ThisGuest.RoomEventFinder(hotel.hotelGraph.HotelNodeSet.FirstOrDefault(n => n.RoomData.AreaType.Equals("Restaurant")), evt);
                    break;
                case HotelEventType.START_CINEMA:
                    break;
                case HotelEventType.NONE:
                    break;
            }
        }
    }
}
