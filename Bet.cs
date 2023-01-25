using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace betandrace
{
    public class Bet
    {
        public int amount;
        public int hound;
        public guy bettor;

        public string GetDescription()
        {
            return $"{this.bettor.name} bets ${this.amount} on dog #{this.hound}";
        }
        public string payout(int winner) { 
            if (winner == hound)
            {
                return $"{bettor.name} won ${amount} on this bet";
            } else
            {
                return $"{bettor.name} lost ${amount} on this bet";
            }
        }
    }
}
