//Bilal Zeineddine
//Footy Store Cash Register
//February 11 2020


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;


namespace CashRegister
{
    public partial class footyStore : Form
    {
        //Set the price of each respective item aswell as creating global variables for the ammount of each item ordered. Set the order number, starting at 001.
        double footballPrice = 15;
        double cleatPrice = 35;
        double jerseyPrice = 10;
        double footballAmmount = 0;
        double cleatAmmount = 0;
        double jerseyAmmount = 0;
        double footballCost = 0;
        double cleatCost = 0;
        double jerseyCost;
        double orderNumber = 0;
        //Set variables for the costs, tax rate, and cost after tax
        double totalCost = 0;
        double taxRate = 0.13;
        double taxAmmount = 0;
        double afterTax = 0;

        //Create variables for the ammount the customer hands over, and the ammount of change due
        double tenderedPaid = 0;
        double changeDue = 0;

        private void calculateButton_Click(object sender, EventArgs e)
        //Create a try catch block in order to prevent crashing if anything other than whole digits is entered into the textbox
        {
            try
            {


                //Grab the ammount that the user has typed into the box, store and convert it. 
                footballAmmount = Convert.ToInt32(footballAmount.Text);
                cleatAmmount = Convert.ToInt32(cleatAmount.Text);
                jerseyAmmount = Convert.ToInt32(jerseyAmount.Text);

                if (footballAmmount == 0 && cleatAmmount == 0 && jerseyAmmount == 0)
                {
                    subLabel2.Text = "Enter a number!";
                    taxLabel2.Text = "";
                    totalLabel2.Text = "";
                    SoundPlayer player = new SoundPlayer(Properties.Resources.error);
                    player.Play();
                    printButton.Enabled = false;
                }
                else
                {
                    footballCost = footballAmmount * footballPrice;
                    jerseyCost = jerseyAmmount * jerseyPrice;
                    cleatCost = cleatAmmount * cleatPrice;
                    //Calculations of the total cost and cost after tax, after reading what the user has entrered into the respective textboxes.
                    totalCost = footballAmmount * footballPrice + cleatAmmount * cleatPrice + jerseyAmmount * jerseyPrice;
                    taxAmmount = totalCost * taxRate;
                    afterTax = totalCost + taxAmmount;
                    printButton.Enabled = false;

                    //Display the calculations above in the Sub total label, the tax label, and the after tax label
                    subLabel2.Text = $"{totalCost.ToString("C")}";
                    taxLabel2.Text = $"{taxAmmount.ToString("C")}";
                    totalLabel2.Text = $"{afterTax.ToString("C")}";
                    //Play "kaching" sound effect when presented with total
                    SoundPlayer player = new SoundPlayer(Properties.Resources.kaching);
                    player.Play();

                }
            }
            catch
            {


                SoundPlayer player2 = new SoundPlayer(Properties.Resources.error);

                player2.Play();
                printButton.Enabled = false;
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        //Create a try catch block in order to prevent the program crashing if letters, or anything except whole digits is entered in the textbox.
        {
            try
            {

                {//Convert to Int32, allow currency addaptation and determine the value of the variable changeDue. Display in the change label.

                    printButton.Enabled = false;
                    tenderedPaid = Convert.ToInt32(tenderedBox.Text);
                    changeDue = Math.Abs(tenderedPaid - afterTax);
                    changeLabel1.Text = $"{changeDue.ToString("C")}";
                    printButton.Enabled = true;
                    //Play the "kaching" sound effect when the money is displayed.
                    SoundPlayer player = new SoundPlayer(Properties.Resources.kaching);

                    player.Play();
                    //See if the tendered paid is less than the total. If that is the case, display an "Invalid Change" message, aswell as disabling the print button.

                    if (tenderedPaid < afterTax)
                    {
                        changeLabel1.Text = $"Invalid Change! Please pay {changeDue.ToString("C")} more!";
                        printButton.Enabled = false;
                        //Play error noise 
                        SoundPlayer player1 = new SoundPlayer(Properties.Resources.error);

                        player1.Play();
                    }
                    else printButton.Enabled = true;
                }
            }
            catch
            {
                //Play error noise if something incorrect is entered in tendered box
                SoundPlayer player1 = new SoundPlayer(Properties.Resources.error);

                player1.Play();
                tenderedBox.Text = "Enter a number!";
                tenderedBox.Focus();

            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            printButton.Enabled = false;

            //Play sound of receipt printing
            SoundPlayer player = new SoundPlayer(Properties.Resources.receipt);

            player.Play();
            //Begin printing the receipt line by line, with pause inbetween. Receipt will push up every line in order to allow next line to show
            //Collect the current date and display it in d/m/y format. Collect the current time and display it as hh:mm am/pm
            receiptLabel.Text += $"Fedes Footy Fanatics\n\n\nOrder #{++orderNumber}\n{receiptLabel.Text = DateTime.Now.ToString("dd-MM-yy")} {receiptLabel.Text = DateTime.Now.ToString("hh:mm tt")} ";
            Refresh();
            Thread.Sleep(1600);
            receiptLabel.Text += $"\n\nFootballs  x{footballAmmount} {footballCost.ToString("C")}";
            Refresh();
            Thread.Sleep(1600);
            receiptLabel.Text += $"\nCleats     x{cleatAmmount} {cleatCost.ToString("C")}";
            Refresh();
            Thread.Sleep(1600);
            receiptLabel.Text += $"\nJerseys    x{jerseyAmmount} {jerseyCost.ToString("C")}";
            Refresh();
            Thread.Sleep(1600);
            receiptLabel.Text += $"\n\nSubtotal:     {totalCost.ToString("C")}";
            Refresh();
            Thread.Sleep(1600);
            receiptLabel.Text += $"\nTax:          {taxAmmount.ToString("C")}";
            Refresh();
            Thread.Sleep(1600);
            receiptLabel.Text += $"\nTotal:        {afterTax.ToString("C")}";
            Refresh();
            Thread.Sleep(1600);
            receiptLabel.Text += $"\n\nTendered:     {tenderedPaid.ToString("C")}";
            Refresh();
            Thread.Sleep(1600);
            receiptLabel.Text += $"\nChange Due:   {changeDue.ToString("C")}";
            Refresh();
            Thread.Sleep(1600);
            receiptLabel.Text += $"\n\nThank you for visiting Fedes Footy Fanatics!";
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            printButton.Enabled = false;
            //Reset all variables to 0 after a new order is placed, enable another receipt to be printed with accurate information
            receiptLabel.Text = "";
            footballAmount.Text = "0";
            cleatAmount.Text = "0";
            jerseyAmount.Text = "0";
            subLabel2.Text = "";
            taxLabel2.Text = "";
            totalLabel2.Text = "";
            tenderedBox.Text = "";
            changeLabel1.Text = "";
            cleatAmmount = 0;
            footballAmmount = 0;
            jerseyAmmount = 0;
            jerseyCost = 0;
            footballCost = 0;
            cleatCost = 0;
            totalCost = 0;
            taxAmmount = 0;
            afterTax = 0;
        }

        private void footyStore_Load(object sender, EventArgs e)
        {
            printButton.Enabled = false;
        }
    }
}

