using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace betandrace
{
    public partial class Form1 : Form
    {
        guy[] guysArray = new guy[3];
        Dog[] dogsArray = new Dog[4];
        bool raceStarted = false;


        public Form1()
        {
            InitializeComponent();
            guysArray[0] = new guy()
            {
                name = "Joe",
                cash = 100,
                radioButton = radioButton1,
                balancetextbox = textBox1,
                myLabel = label6
                
            };
            guysArray[1] = new guy()
            {
                name = "Bob",
                cash = 100,
                radioButton = radioButton2,
                balancetextbox = textBox2,
                myLabel = label7
            };
            guysArray[2] = new guy()
            {
                name = "Al",
                cash = 100,
                radioButton = radioButton3,
                balancetextbox = textBox3,
                myLabel = label8
            };
            guysArray[0].balancetextbox.Text = guysArray[0].cash.ToString();
            guysArray[1].balancetextbox.Text = guysArray[1].cash.ToString();
            guysArray[2].balancetextbox.Text = guysArray[2].cash.ToString();
            dogsArray[0] = new Dog()
            {
                name = "Lucy",
                number = 1,
                RacetrackLength = pictureBox5.Location.X - 40,
                myPictureBox = pictureBox1
            };
            dogsArray[1] = new Dog()
            {
                name = "jack",
                number = 2,
                RacetrackLength = pictureBox5.Location.X - 40,
                myPictureBox = pictureBox2
            };
            dogsArray[2] = new Dog()
            {
                name = "Lucy",
                number = 3,
                RacetrackLength = pictureBox5.Location.X - 40,
                myPictureBox = pictureBox3
            };
            dogsArray[3] = new Dog()
            {
                name = "Lucy",
                number = 4,
                RacetrackLength = pictureBox5.Location.X - 40,
                myPictureBox = pictureBox4
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                if (guysArray[i].radioButton.Checked)
                {
                    guysArray[i].placeBet((int)numericUpDown2.Value, (int)numericUpDown3.Value);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (Dog i in dogsArray)
            {
                i.RestRace();
                this.raceStarted = false;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startRaceButton_Click(object sender, EventArgs e)
        {
            if (this.raceStarted)
            {
                MessageBox.Show("Reset Race First don't be in a hurry", "why are you running why are you running");
            }
            else
            {


                this.raceStarted = true;
                bool stop = false;
                Random nums = new Random();
                while (true)
                {
                    foreach (Dog i in dogsArray)
                    {
                        stop = i.Run(nums.Next(9));
                        if (stop)
                        {
                            foreach (guy man in guysArray)
                            {
                                if (man.myBet != null)
                                {


                                    if (man.myBet.hound == i.number)
                                    {
                                        
                                        man.myLabel.Text = man.myBet.payout(i.number);
                                        man.collectBet();
                                    }
                                    else
                                    {
                                        man.myLabel.Text = man.myBet.payout(i.number);
                                        man.clearBet();
                                    }
                                }
                            }
                            break;
                        }

                    }
                    if (stop)
                    {
                        break;
                    }
                }
            }
        }
    }
}
