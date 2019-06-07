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
    public partial class updateRes : Form
    {
        
        public updateRes()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void updateRes_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("benyt et bookingnummer");
                return;
            }
            else
            {
                DBController controller = new DBController();
                controller.FindRessourceBookinger(Convert.ToInt32(textBox1.Text));
                foreach (var item in controller.ressBookList)
                {
                    ListViewItem itm = new ListViewItem();
                    itm.SubItems.Add(item.ResNr.ToString());
                    itm.SubItems.Add(item.Navn);
                    itm.SubItems.Add(item.Rnr.ToString());
                    itm.SubItems.Add(item.Aargang.ToString());
                    itm.SubItems.Add(item.Maerke);
                    itm.SubItems.Add(item.Pris.ToString());
                    itm.SubItems.Add(item.StartDato);
                    itm.SubItems.Add(item.SlutDato);
                    listView1.Items.Add(itm);
                }


            }

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //insert data til startdato, slutdato og pris;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //DBController controller = new DBController();
            //controller.UpdateReserveringlinjeRessourcer(ResNr, orderstart, orderslut, total, book_ID);

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //DBController controller = new DBController();
            //controller.SletReserveringlinjeRessourcer(Resnr);

        }
    }
}
