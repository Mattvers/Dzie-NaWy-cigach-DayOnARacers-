using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Races_v1_0
{
    public class Guy
    {
        public string Name;  //name of player
        public Bet MyBet = new Bet();   // object of class Bet that have a information about bet
        public int Cash; //money that player have

        public RadioButton MyRadioButton; // button that player choose
        public Label myLabel; //label that player have

        //-----------------------------------------------METHODS-------------------------------------

        //class constructor that join object myBet
        public Guy()
        {
            MyBet.Bettor = this;
        }

        // method that updating all player labels 
        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " ma " + Cash + " zł";
            myLabel.Text = MyBet.GetDescription();
        }
        
        // method to clear the bet
        public void ClearBet()
        {
            MyBet.Dog = 0;
            MyBet.Amount = 0;
        }


        /// <summary>
        ///  Method that doing a bet to a dog in a race.
        /// </summary>
        /// <param name="Amount">money that player wants to bet on dog</param>
        /// <param name="DogToWin">numbet of dog that player wants to bet</param>
        /// <returns>true if bet is correct, false if bet is incorect</returns>
        public bool PlaceBet(int Amount, int DogToWin)
        {
            if (Cash >= Amount)
            {
                MyBet.Amount = Amount;
                MyBet.Dog = DogToWin;
                UpdateLabels();
                return true;
            }
            else
            {
                MessageBox.Show(Name + " nie posiada wystarczająco pieniędzy. Przepraszamy.");
                return false;
            }
        }


        /// <summary>
        /// Method that actualize money
        /// </summary>
        /// <param name="Winner">number of winner dog</param>
        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
        }


        public void UpdateLabelBetting()
        {
            int ad = 0;
            ad = Cash - MyBet.Amount;
            MyRadioButton.Text = Name + " ma " + ad + " zł";
        }

    }
}
