using HotelEvents;

namespace Hotel_Simulator
{
    public class HotelEventManager  // Manages the incomming hotel events
    {
        public HotelEventManager()
        {
            HotelEvents.HotelEventManager.HTE_Factor = 5f;
        }

        public void Pauze()
        {
            HotelEvents.HotelEventManager.HTE_Factor = 0f;
        }
        public void Resume()
        {
            HotelEvents.HotelEventManager.HTE_Factor = 5f;
        }
        public void SpeedUp()
        {
            HotelEvents.HotelEventManager.HTE_Factor = 10f;
        }
        
        public void SlowDown()
        {
            HotelEvents.HotelEventManager.HTE_Factor = 2.5f;
        }

        public void ResetSpeed()
        {
            HotelEvents.HotelEventManager.HTE_Factor = 5;
        }
        public void StartEvents()
        {
            HotelEvents.HotelEventManager.Start();
        }
        public void StopEvents()
        {
            HotelEvents.HotelEventManager.Stop();
        }

        public void RegisterListener(HotelEventObserver listener)
        {
            HotelEvents.HotelEventManager.Register(listener);
        }

        public void DeregisterListener(HotelEventObserver listener)
        {
            HotelEvents.HotelEventManager.Deregister(listener);
        }
    }
}
