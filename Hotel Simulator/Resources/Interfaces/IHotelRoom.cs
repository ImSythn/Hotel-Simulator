using System.Collections.Generic;

namespace Hotel_Simulator
{
    public interface IHotelRoom
    {
        bool Occupied { get; set; }
        List<IHuman> HumanList { get; set; }
        void AddHuman(IHuman human);
        void RemoveHuman(IHuman human);
    }
}
