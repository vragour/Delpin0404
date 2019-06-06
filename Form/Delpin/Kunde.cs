using System;
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
    public partial class Kunde : Form
    {
        DBController controller = new DBController();
        
        public Kunde()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Navn", 60);
            listView1.Columns.Add("Adresse", 60);
            listView1.Columns.Add("PostNr", 60);
            listView1.Columns.Add("By", 60);
            listView1.Columns.Add("DebitorNr", 60);
            listView1.Columns.Add("KundeType", 60);
            listView1.Columns.Add("TLF", 60);
            listView1.Columns.Add("KundeNr", 60);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpretKunde opretKunde = new OpretKunde();
            opretKunde.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vil du slette kunden", "Sletning af kunde", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                controller.DeleteDebitor(listView1.SelectedItems[0].SubItems[6].Text);
            }
            else if (dialogResult == DialogResult.No)
            {
                //gør ingenting
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            controller.UpdatetDebitor(textBox1.Text,
                                      textBox2.Text,
                                      int.Parse(textBox3.Text),
                                      textBox4.Text,
                                      textBox5.Text,
                                      textBox6.Text,
                                      textBox7.Text,
                                      textBox8.Text );
        }

        private void button2_Click(object sender, EventArgs e)//search
        {
            /*Needs Error handling for when nothing is typed in textBox9*/
            DebitorObj debitorObj = controller.HentDebitor(textBox9.Text);

            string[] arr = new string[8];
            
                arr[0] = debitorObj.Navn;
                arr[1] = debitorObj.Adresse;
                arr[2] = debitorObj.PostNr.ToString();
                arr[3] = debitorObj.By;
                arr[4] = debitorObj.DebitorNr;
                arr[5] = debitorObj.KundeType;
                arr[6] = debitorObj.Tlf;
                arr[7] = debitorObj.KundeNr;

            ListViewItem itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox8.Text = listView1.SelectedItems[0].SubItems[7].Text;
        }
    }
}
