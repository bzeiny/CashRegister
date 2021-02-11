﻿using System;
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
        //Set the price of each respective item aswell as creating global variables for the ammount of each item ordered.
        double footballPrice = 15;
        double cleatPrice = 35;
        double jerseyPrice = 10;
        double footballAmmount = 0;
        double cleatAmmount = 0;
        double jerseyAmmount = 0;
        double footballCost = 0;
        double cleatCost = 0;
        double jerseyCost;
        //Set variables for the costs, tax rate, and cost after tax
        double totalCost = 0;
        double taxRate = 0.13;
        double taxAmmount = 0;
        double afterTax = 0;

        //Create variables for the ammount the customer hands over, and the ammount of change due
        double tenderedPaid = 0;
        double changeDue = 0;




        public footyStore()
        {
            InitializeComponent();
        }

        private void subLabel_Click(object sender, EventArgs e)
        {

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            //Play "kaching" sound effect when presented with total
            SoundPlayer player = new SoundPlayer(Properties.Resources.kaching);
            player.Play();

            //Grab the ammount that the user has typed into the box, store and convert it. 
            footballAmmount = Convert.ToInt32(footballTextBox.Text);
            cleatAmmount = Convert.ToInt32(cleatsTextBox.Text);
            jerseyAmmount = Convert.ToInt32(jerseyTextBox.Text);
            footballCost = footballAmmount * footballPrice;
            jerseyCost = jerseyAmmount * jerseyPrice;
            cleatCost = cleatAmmount * cleatPrice;
            //Calculations of the total cost and cost after tax, after reading what the user has entrered into the respective textboxes.
            totalCost = footballAmmount * footballPrice + cleatAmmount * cleatPrice + jerseyAmmount * jerseyPrice;
            taxAmmount = totalCost * taxRate;
            afterTax = totalCost + taxAmmount;
            

            //Display the calculations above in the Sub total label, the tax label, and the after tax label
            subLabel2.Text = $"{totalCost.ToString("C")}";
            taxLabel2.Text = $"{taxAmmount.ToString("C")}";
            totalLabel2.Text = $"{afterTax.ToString("C")}";

        }

        private void changeButton_Click(object sender, EventArgs e)
        {//Convert to Int32, allow currency addaptation and determine the value of the variable changeDue. Display in the change label.
         //Play the "kaching" sound effect when the money is displayed.
            SoundPlayer player = new SoundPlayer(Properties.Resources.kaching);

            player.Play();
            tenderedPaid = Convert.ToInt32(tenderedBox.Text);
            changeDue = tenderedPaid - afterTax;
            changeLabel1.Text = $"{changeDue.ToString("C")}";
        }





        private void printButton_Click(object sender, EventArgs e)
        {
            //Play sound of receipt printing
            SoundPlayer player = new SoundPlayer(Properties.Resources.receipt);

            player.Play();
            //Begin printing the receipt line by line, with pause inbetween. Receipt will push up every line in order to allow next line to show
            receiptLabel.Text += $"Fedes Footy Store\n\n\nOrder #734\nFebuary 11th, 2021";
            Refresh();
            Thread.Sleep(2000);
            receiptLabel.Text += $"\n\nFootballs x{footballAmmount} {footballCost.ToString("C")}";
            Refresh();
            Thread.Sleep(2000);
            receiptLabel.Text += $"\nCleats x{cleatAmmount} {cleatCost.ToString("C")}";
            Refresh();
            Thread.Sleep(2000);
            receiptLabel.Text += $"\nJerseys x{ jerseyAmmount} {jerseyCost.ToString("C")}";
            Refresh();
            Thread.Sleep(2000);
            receiptLabel.Text += $"\n\nSubtotal:{totalCost.ToString("C")}";
            Refresh();
            Thread.Sleep(2000);
            receiptLabel.Text += $"\nTax:{taxAmmount.ToString("C")}";
            Refresh();
            Thread.Sleep(2000);
            receiptLabel.Text += $"\nTotal:{afterTax.ToString("C")}";
            Refresh();
            Thread.Sleep(2000);
            receiptLabel.Text += $"\n\nThank you for visiting Fedes Footy Store!";



        }

        private void newButton_Click(object sender, EventArgs e)
        {
            //Reset all variables to 0 after a new order is placed, enable another receipt to be printed with accurate information
            receiptLabel.Text = "";
            footballTextBox.Text = "";
            cleatsTextBox.Text = "";
            jerseyTextBox.Text = "";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

