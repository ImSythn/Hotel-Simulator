using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Hotel_Simulator
{
    public class RoomLoader
    {
        public static List<RoomObject> LoadHotel() //Deserializes JSON file and puts it in a list of room objects. Added AreaType ElevatorStairwell which hight can dynamically change in ElevatorStairwell. 
        {
            using (StreamReader r = new StreamReader(@"../../Resources/JSON Files/Hotel.json"))
            {
                string json = r.ReadToEnd();
                List<RoomObject> roomSpecificationList = JsonConvert.DeserializeObject<List<RoomObject>>(json);
                return roomSpecificationList;
            }
        }
    }
}
