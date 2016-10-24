using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Races_v1_0
{
    public partial class ApplicationForm : Form
    {

        Greyhound[] greyhoundersArray = new Greyhound[4];  //create table of greyhounds objects
        Random myRandomizer = new Random(); //inicializee randomize
        Guy[] guysArray = new Guy[3]; //create table of guys objects

        /// <summary>
        /// Public void method that inicialize table guys[] with objects. Also it sets opportunetly fields;
        /// </summary>
        public void InitializeGuys()
        {
            guysArray[0] = new Guy()
            {
                Name = "Joe",
                Cash = 50,
                MyRadioButton = joeRadioButton,
                myLabel = joeBetLabel               
            };
            guysArray[0].UpdateLabels();

            guysArray[1] = new Guy()
            {
                Name = "Vito",
                Cash = 75,
                MyRadioButton = vitoRadioButton,
                myLabel = vitoBetLabel
            };
            guysArray[1].UpdateLabels();

            guysArray[2] = new Guy()
            {
                Name = "Tom",
                Cash = 45,
                MyRadioButton = tomRadioButton,
                myLabel = tomBetLabel
            };
            guysArray[2].UpdateLabels();
        }

        /// <summary>
        /// Public void method that inicialize table greyhounders[] with objects. Also it sets opportunetly fields;
        /// </summary>
        public void InitializeGreyhounders()
        {           
            for (int i = 0; i < 4; i++)
            {
                greyhoundersArray[i] = new Greyhound()
                {                   
                    StartingPosition = greyHoundPictureBox2.Left,
                    RaceTrackLength = speedwayPictureBox.Width - greyHoundPictureBox2.Width,
                    MyRandom = myRandomizer
                };              
            }
            greyhoundersArray[0].MyPicturebox = greyHoundPictureBox1;
            greyhoundersArray[1].MyPicturebox = greyHoundPictureBox2;
            greyhoundersArray[2].MyPicturebox = greyHoundPictureBox3;
            greyhoundersArray[3].MyPicturebox = greyHoundPictureBox4;
        }           


        public ApplicationForm()
        {
            InitializeComponent();
            InitializeGuys();
            InitializeGreyhounders();           
        }
                
        // void to start a timer when user click on startbutton          
        private void startButton_Click(object sender, EventArgs e)
        {
            groupBox.Enabled = false;
            timer.Start();
        }

        /// <summary>
        /// Void to operate in time on this project. We do every time changes for four greyhounders objects;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)  //dla wszystkich chartów
            {
                if (greyhoundersArray[i].Run())
                {
                    timer.Stop();
                    MessageBox.Show("Gonitwe wygrał chart numer  " + (i+1));
                    for (int j = 0; j <= 3; j++)
                    {
                        greyhoundersArray[j].TakeStartingPosition();
                    }
                  
                    for (int k = 0; k < 3; k++)
                    {
                        guysArray[k].Collect(i+1);
                        guysArray[k].ClearBet();
                        guysArray[k].UpdateLabels();
                    }
                    groupBox.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Method that checked what NumericUpDown is active, and then do right commands
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void betButton_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                guysArray[0].PlaceBet((int)betLargeNumericUpDown.Value,(int)chartNumericUpDown.Value);
                guysArray[0].UpdateLabelBetting();
            }
            else if (vitoRadioButton.Checked)
            {             
                guysArray[1].PlaceBet((int)betLargeNumericUpDown.Value, (int)chartNumericUpDown.Value);
                guysArray[1].UpdateLabelBetting();
            }
            else if (tomRadioButton.Checked)
            {             
                guysArray[2].PlaceBet((int)betLargeNumericUpDown.Value, (int)chartNumericUpDown.Value);
                guysArray[2].UpdateLabelBetting();
            }
            
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Joe";
        }

        private void vitoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Vito";
        }

        private void tomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Tom";
        }
    }
}
