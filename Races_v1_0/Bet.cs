using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Races_v1_0
{
    public class Bet
    {
        public int Amount;  //money thats player bet
        public int Dog;  // dog numbet thats player bet
        public Guy Bettor; //player whos betting

        //--------------------------------------------------METHODS--------------------------------------------------

        /// <summary>
        /// Method that gave a information about current betting player betting
        /// </summary>
        /// <returns>information string of bet</returns>
        public string GetDescription()
        {
            string answer = "";

            if (Amount >= 5 && Amount <= 15)
            {
                return Bettor.Name + " postawił " + Amount + " zł na charta o numerze " + Dog;
                
            }
            else
            {
                answer = this.Bettor.Name + " nie zawarł jeszcze zakładu...";
                return answer;
            }
        }

        /// <summary>
        /// Method checking if player choose the dog, which wins the race.
        /// </summary>
        /// <param name="Winner">this is number of dog, who win the race</param>
        /// <returns>Cash that player earn or lose in this bet</returns>
        public int PayOut(int Winner)
        {
            if (Winner == Dog)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
        }

    }
}
