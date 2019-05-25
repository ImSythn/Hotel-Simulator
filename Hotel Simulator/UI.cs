using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;


namespace Hotel_Simulator
{
    public class UI : Hotel
    {
        private Hotel drawHotel;
        private Button pauzeButton;
        private Button continueButton;
        private Button speedUpButton;
        private Button slowDownButton;
        private Button resetSpeedButton;
        public UI(Hotel drawHotel)
        {
            this.drawHotel = drawHotel;
        }
        #region UI buttons
        public void DrawButtons()
        {
            pauzeButton = new Button()
            {
                BackgroundImage = Image.FromFile(@"..\..\Resources\Images\PauseButton.png"),
                Size = new Size(100, 50),
                BackColor = Color.Green,
                Visible = true,
                Location = new Point(0, 525),

            };
            pauzeButton.Click += PauzeButton_Click;

            continueButton = new Button()
            {
                BackgroundImage = Image.FromFile(@"..\..\Resources\Images\ResumeButton.png"),
                Size = new Size(100, 50),
                BackColor = Color.Green,
                Visible = true,
                Location = new Point(100, 525),

            };  
            continueButton.Click += ContinueButton_Click;

            speedUpButton = new Button()
            {
                BackgroundImage = Image.FromFile(@"..\..\Resources\Images\SpeedUpButton.png"),
                Size = new Size(100, 50),
                BackColor = Color.Green,
                Visible = true,
                Location = new Point(400, 525),
            };

            speedUpButton.Click += SuperSpeedButton_Click;

            slowDownButton = new Button()
            {
                BackgroundImage = Image.FromFile(@"..\..\Resources\Images\SlowDownButton.png"),
                Size = new Size(100, 50),
                BackColor = Color.Green,
                Visible = true,
                Location = new Point(200, 525),

            };
            slowDownButton.Click += SlowDownButton_Click;

            resetSpeedButton = new Button()
            {
                BackgroundImage = Image.FromFile(@"..\..\Resources\Images\ResetSpeedButton.png"),
                Size = new Size(100, 50),
                BackColor = Color.Green,
                Visible = true,
                Location = new Point(300, 525),

            };
            resetSpeedButton.Click += ResetSpeedButton_Click;

            StartHotel();
        }

        private void ResetSpeedButton_Click(object sender, EventArgs e)
        {
            drawHotel.eventManager.ResetSpeed();
            drawHotel.hotelTickrate.Interval = 1000;
        }

        private void SlowDownButton_Click(object sender, EventArgs e)
        {
            drawHotel.eventManager.SlowDown();
            drawHotel.hotelTickrate.Interval = 2000;
        }

        private void SuperSpeedButton_Click(object sender, EventArgs e)
        {
            drawHotel.eventManager.SpeedUp();
            drawHotel.hotelTickrate.Interval = 500;
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            drawHotel.eventManager.Resume();
            drawHotel.hotelTickrate.Start();
        }

        private void PauzeButton_Click(object sender, EventArgs e)
        {
            drawHotel.eventManager.Pauze();
            drawHotel.hotelTickrate.Stop();
        }
        #endregion 

        private void StartHotel()  // Starts the hotel from loading in.
        {
            drawHotel.Controls.Add(pauzeButton);
            drawHotel.Controls.Add(continueButton);
            drawHotel.Controls.Add(speedUpButton);
            drawHotel.Controls.Add(slowDownButton);
            drawHotel.Controls.Add(resetSpeedButton);
            List<RoomObject> roomSpecificationList = RoomLoader.LoadHotel();
            drawHotel.hotelGraph.GenerateGraph(roomSpecificationList);
            drawHotel.hotelGraph.AddHotelEdge();
            drawHotel.LoadObjects();
        }
    }
}
