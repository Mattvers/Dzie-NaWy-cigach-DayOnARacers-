using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Races_v1_0
{
    public class Greyhound
    {
        public int StartingPosition; //starting position of Greyhound
        public int RaceTrackLength; //all race length
        public PictureBox MyPicturebox = null; // object my picturebox like Greyhart
        public int Location = 0; //current location of object
        public Random MyRandom; // random

        // ------------------------------------- METHODS--------------------------------------------

        /// <summary>
        /// Public method to Run a object on race field. 
        /// </summary>
        /// <returns> bool parametr (true/false) that means the move is or not</returns>                  
        public bool Run()           
        {                                
            MyPicturebox.Left += MyRandom.Next(1, 5);
            Location = MyPicturebox.Left;

            if (Location >= RaceTrackLength - MyPicturebox.Width + 68)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Public method that reset the starting position of Greyhound object
        /// </summary>
        public void TakeStartingPosition()
        {
            MyPicturebox.Left = 20; 
            Location = 0;          
        }
    }
}
