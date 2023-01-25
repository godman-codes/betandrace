using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace betandrace
{
    public class guy
    {
        public string name;
        public int cash;
        public TextBox balancetextbox;
        public Bet myBet;
        public Label myLabel;
        public RadioButton radioButton;

        public bool placeBet(int amount, int dog)
        {
            decimal value = (decimal)amount;
            decimal balance = (decimal)this.cash;
            if (value < 5)
            {
                MessageBox.Show("bet must be at least 5$", "traction failed");
                return false;

            }
            else if (value > balance)
            {
                MessageBox.Show("insufficient funds", "traction failed");
                return false;

            }
            else
            {
                balance -= value;

                if (this.myBet != null)
                {
                    if (this.myBet.amount > 0)
                    {
                        this.myBet.amount += amount;
                    }
                }
                else
                {
                    this.myBet = new Bet()
                     {
                        amount = amount,
                        hound = dog,
                        bettor = this
                    };
                }
                this.cash = (int)balance;
                this.updateLabels();
                

                return true;
            }
        }
        public void clearBet()
            {
            this.myBet = null;
        }
        public void collectBet()
        {
            this.cash += (this.myBet.amount*2);
            this.updateLabels(alternator: true);
            this.clearBet();
        }
        public void updateLabels(bool alternator = false)
        {
            this.balancetextbox.Text = $"{this.cash}";
            if (!alternator)
            {

                this.myLabel.Text = this.myBet.GetDescription();
            }
        }
        //public void collectUpdatelabels()
        //{
        //    this.balancetextbox.Text = $"{this.cash}";
        //    this.myLabel.Text = this.myBet.GetD();
        //}
    }
}
