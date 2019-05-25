using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HotelEvents;

namespace Hotel_Simulator
{
    public partial class Hotel : Form
    {
        public HotelGraph hotelGraph;
        public HotelEventManager eventManager;
        public HotelEventObserver listener;
        public UI UILayout;
        public HotelNode lobbyNode;
        public Timer hotelTickrate;
        public List<IHuman> humanList;
        public Hotel()
        {
            InitializeComponent();
            hotelTickrate = new Timer();                                                                     // Tickrate of the hotel. Every move of every person runs at this interval.
            hotelTickrate.Interval = 750;
            hotelTickrate.Tick += HotelTickrate_Tick;
        }

        private void Hotel_Load(object sender, EventArgs e)
        {
            hotelGraph = new HotelGraph();                                                                   // Keeps a list of all the hotel nodes and connections in the form of a graph.
            UILayout = new UI(this);                                                                         // Draws different buttons in different locations for simple controlls.
            humanList = new List<IHuman>();                                                                  // Keeps a list of all the guests in the hotel.
            UILayout.DrawButtons();
        }

        public void LoadObjects()
        {
            lobbyNode = hotelGraph.HotelNodeSet.FirstOrDefault(n => n.RoomData.AreaType.Equals("Lobby"));    // Keeps the hotelNode where the lobby is on.
            HotelRoomFactory hotelRoomFactory = new HotelRoomFactory();
            foreach (HotelNode hotelNode in hotelGraph.HotelNodeSet)
            {
                Controls.Add(hotelNode);
                hotelNode.HotelObject = hotelRoomFactory.HotelRooms(hotelNode);                              
            }
            eventManager = new HotelEventManager();                                                          
            listener = new HotelEventObserver(this);                                                         
            eventManager.StartEvents();                                                                      // Starts the hotel events.
            eventManager.RegisterListener(listener);                                                         // Registers the listener to the event manager.
            hotelTickrate.Start();
        }

        private void HotelTickrate_Tick(object sender, EventArgs e)
        {
            foreach (IHuman human in humanList)
            {
                human.Move();
            }
        }

        private void Hotel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(eventManager != null)                                                                         // Stops and deregisters the lister. 
            {
                eventManager.StopEvents();
                eventManager.DeregisterListener(listener);
            }
        }
    }
}
