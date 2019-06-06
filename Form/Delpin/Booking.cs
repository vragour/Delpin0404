﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backend;
namespace Delpin
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker2.MinDate = DateTime.Today;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                    }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Booking_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox8.Text) || String.IsNullOrWhiteSpace(textBox8.Text))
                return;
            DBController dBController = new DBController();
            string startdate = Convert.ToString(dateTimePicker1.Value.Date.ToString("yyyy/MM/dd"));
            string slutdate = Convert.ToString(dateTimePicker2.Value.Date.ToString("yyyy/MM/dd"));
            string search = textBox8.Text;
            dBController.FindFrieRessourcerMaerkelNavn(startdate, slutdate, search);

            //uncommen hvis man skal se string af dato
            //MessageBox.Show(startdate);
            //MessageBox.Show(slutdate);
            foreach (var item in dBController.ressources)
            {
                ListViewItem itm = new ListViewItem(item.Navn, 0);
                itm.SubItems.Add(Convert.ToString(item.Rnr));
                itm.SubItems.Add(item.Maerke);
                itm.SubItems.Add(Convert.ToString(item.Anr));
                itm.SubItems.Add(Convert.ToString(item.Pris));
                itm.SubItems.Add(Convert.ToString(item.Aargang));
                // til føj til ressourcerlisten
                listView2.Items.Add(itm);

            }


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var selectedItem = listView2.SelectedItems[0];
            ListViewItem listViewItem = new ListViewItem();
            listViewItem = selectedItem;
            listViewItem.SubItems.Add(Convert.ToString(dateTimePicker1.Value.Date.ToString("yyyy/MM/dd")));
            listViewItem.SubItems.Add(Convert.ToString(dateTimePicker2.Value.Date.ToString("yyyy/MM/dd")));
            listView2.SelectedItems[0].Remove();
            listView4.Items.Add(listViewItem);


            //listView4.Items.Add
            
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_dropdown(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker2.Value < dateTimePicker1.Value)
            {
                string beforeStart = "Slutdatoen skal være efter den valgte startdato";
                MessageBox.Show(beforeStart);
                dateTimePicker2.Value = dateTimePicker1.Value;
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void ListView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Button8_Click(object sender, EventArgs e)
        {

        }


        // sletning fra booking
        private void Button5_Click(object sender, EventArgs e)
        {
            var selectedItem = listView4.SelectedItems[0];
            ListViewItem listViewItem = new ListViewItem();
            listViewItem = selectedItem;
            listView4.SelectedItems[0].Remove();
            listView2.Items.Add(listViewItem);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            DBController dBController = new DBController();

            
            dBController.HentDebitor(textBox1.Text);
            if (dBController.debitor.Count() == 1) {
                foreach (var item in dBController.debitor)
                {
                    label13.Text = item.Navn;
                    label12.Text = item.Adresse;
                    label11.Text = item.By;
                    Label8.Text = item.PostNr;
                    lab
                    if (item.KundeType == "F")
                    {
                        label15.Text = item.KundeNr;
                    }
                    else
                    {
                        label7.Text = item.KundeNr;
                    }
                    label17.Text = item.Tlf;
                    label19.Text = item.
                }
            }
            else
            {
                MessageBox.Show("Ingen kunde med dette tlf, opret en ny");
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }

        private void Label19_Click(object sender, EventArgs e)
        {

        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }
    }
}
