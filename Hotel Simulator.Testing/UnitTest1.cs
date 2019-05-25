using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using Hotel_Simulator;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Hotel_Simulator.Testing
{
    [TestClass]
    public class MovementTesting
    {
        [TestMethod]
        public void CreateHotel_OfTypeHotel_HasValue()
        {
            // Arrange
            Hotel hotel = new Hotel();
            // Act

            // Assert
            Assert.IsNotNull(hotel);
        }
        [TestMethod]
        public void CheckEventManagerStart_OfTypeHotelEvent_IsActive()
        {
            // Arrange
            Hotel hotel = new Hotel();
            HotelEventManager hotelEventManager = new HotelEventManager();
            HotelEventObserver hotelEventObserver = new HotelEventObserver(hotel);
            bool expected = true;
            bool result = false;
            // Act
            HotelEvents.HotelEventManager.Start();
            HotelEvents.HotelEventManager.Register(hotelEventObserver);
            while (result == false)
            {
                result = HotelEvents.HotelEventManager.Running;
            }
            HotelEvents.HotelEventManager.Stop();
            HotelEvents.HotelEventManager.Deregister(hotelEventObserver);
            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CreateHumanObject_OfTypeGuest_IsInstanceOfType()
        {
            // Arrange
            HumanSchematic newGuest = new Guest(null, null, null);
            // Act

            // Assert
            Assert.IsInstanceOfType(newGuest, typeof(Guest));
        }
        [TestMethod]
        public void CreateRoomObjectWithFactory_OfTypeRoom_IsInstanceOfType()
        {
            // Arramge
            Hotel hotel = new Hotel();
            RoomObject roomObject = new RoomObject();
            HotelRoomFactory hotelRoomFactory = new HotelRoomFactory();
            HotelNode hotelNode = new HotelNode(roomObject, 0);
            roomObject.AreaType = "Room";
            // Act
            hotelNode.HotelObject = hotelRoomFactory.HotelRooms(hotelNode);
            // Assert
            Assert.IsInstanceOfType(hotelNode.HotelObject, typeof(Room));
        }
        [TestMethod]
        public void FindSpecificOpenRoom_OfTypeHotelNode_AreEqual()
        {
            // Arrange
            HumanSchematic newGuest = new Guest(null, null, null);
            List<HotelNode> hotelNodes = new List<HotelNode>();
            HotelRoomFactory hotelRoomFactory = new HotelRoomFactory();
            RoomObject RandomObject = new RoomObject()
            {
                Classification = "1 Star",
                ID = 11,
                AreaType = "Room",
                Position = new Point(7, 1),
                Dimension = new Point(1, 1)
            };
            RoomObject expectedObject = new RoomObject()
            {
                Classification = "4 stars",
                ID = 25,
                AreaType = "Room",
                Position = new Point(3, 2),
                Dimension = new Point(2, 1)
            };
            HotelNode randomHotelNode = new HotelNode(RandomObject, 0);
            HotelNode expected = new HotelNode(expectedObject, 0);
            Dictionary<string, string> Data = new Dictionary<string, string>();
            // Act
            randomHotelNode.HotelObject = hotelRoomFactory.HotelRooms(randomHotelNode);
            expected.HotelObject = hotelRoomFactory.HotelRooms(expected);
            hotelNodes.Add(randomHotelNode);
            hotelNodes.Add(expected);
            Data.Add("Gast1", "Checkin 4stars");
            HotelNode result = newGuest.FindSpecificOpenRoom(Data, hotelNodes);
            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DijkstraPathfinding_OfTypeHotelNode_AreEqual()
        {
            // Arrange
            List<HotelNode> hotelNodes = new List<HotelNode>();
            HotelRoomFactory hotelRoomFactory = new HotelRoomFactory();
            List<HotelNode> expected = new List<HotelNode>();
            RoomObject startObject = new RoomObject()
            {
                Classification = "1 Star",
                ID = 11,
                AreaType = "Room",
                Position = new Point(7, 1),
                Dimension = new Point(1, 1)
            };
            RoomObject endObject = new RoomObject()
            {
                Classification = "5 stars",
                ID = 12,
                AreaType = "Room",
                Position = new Point(6, 1),
                Dimension = new Point(2, 1)
            };
            HotelNode startHotelNode = new HotelNode(startObject, 0);
            HotelNode endHotelNode = new HotelNode(endObject, 0);
            Dictionary<string, string> data = new Dictionary<string, string>();
            // Act
            startHotelNode.HotelObject = hotelRoomFactory.HotelRooms(startHotelNode);
            endHotelNode.HotelObject = hotelRoomFactory.HotelRooms(endHotelNode);
            hotelNodes.Add(startHotelNode);
            hotelNodes.Add(endHotelNode);
            expected.Add(endHotelNode);
            startHotelNode.RoomNeighbour.Add(new HotelEdge(startHotelNode, endHotelNode));
            endHotelNode.RoomNeighbour.Add(new HotelEdge(endHotelNode, startHotelNode));
            data.Add("Gast1", "Checkin 5stars");
            Guest guest = new Guest(startHotelNode, data, hotelNodes);
            // Assert
            Assert.AreEqual(expected[0].RoomData, guest.specificRoomDirections[0].RoomData);
        }
        [TestMethod]
        public void CreateGraph_OfTypeHotelGraph_AreEqual()
        {
            // Arrange
            List<RoomObject> roomObjects = new List<RoomObject>();
            RoomObject randomRoom1 = new RoomObject()
            {
                Classification = "2 Star",
                ID = 11,
                AreaType = "Room",
                Position = new Point(7, 1),
                Dimension = new Point(1, 1)
            };
            RoomObject randomRoom2 = new RoomObject()
            {
                Classification = "3 stars",
                ID = 12,
                AreaType = "Room",
                Position = new Point(6, 1),
                Dimension = new Point(1, 1)
            };
            roomObjects.Add(randomRoom1);
            roomObjects.Add(randomRoom2);
            HotelGraph hotelGraph = new HotelGraph();
            HotelNode randomHotelNode1 = new HotelNode(randomRoom1, 0);
            HotelNode randomHotelNode2 = new HotelNode(randomRoom2, 0);
            List<HotelEdge> expectedHotelEdges = new List<HotelEdge>();
            HotelEdge expectedhotelEdge1 = new HotelEdge(randomHotelNode2, randomHotelNode1);
            // Act
            hotelGraph.GenerateGraph(roomObjects);
            hotelGraph.AddHotelEdge();
            expectedHotelEdges.Add(expectedhotelEdge1);
            // Assert
            Assert.AreEqual(expectedHotelEdges[0].RoomDestination.RoomData, hotelGraph.HotelNodeSet[0].RoomNeighbour[0].RoomDestination.RoomData);
        }
    }
}
