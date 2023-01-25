using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace betandrace
{
    public class Dog
    {
        public string name;
        public int number;
        public int startingPosition;
        public int RacetrackLength;
        public PictureBox myPictureBox;
        public int location;
        public Random Randomizer = new Random();
        

        public bool Run(int tool)
        {
            this.TakeStartingPosition();
            location += tool;
            //MessageBox.Show($"{location}");
            
            this.myPictureBox.Location = new Point(location, this.myPictureBox.Location.Y);
            if (location >= RacetrackLength)
            {
                return true;
            }
            return false;
            
        }
        public int TakeStartingPosition()
        {
            startingPosition = myPictureBox.Location.X;
            //this.myPictureBox.Location = new Point(startingPosition, this.myPictureBox.Location.Y);
            location = startingPosition;
            return startingPosition;
        }
        public void RestRace()
        {
            myPictureBox.Location = new Point(88, this.myPictureBox.Location.Y);
        }
    }
}
