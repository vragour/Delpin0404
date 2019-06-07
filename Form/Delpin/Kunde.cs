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

            listView1.Columns.Add("ResNr", 70);
            listView1.Columns.Add("Rnr", 70);
            listView1.Columns.Add("BookingID", 70);
            listView1.Columns.Add("Navn", 70);
            listView1.Columns.Add("Maerke", 70);
            listView1.Columns.Add("StartDato", 70);
            listView1.Columns.Add("SlutDato", 70);
            listView1.Columns.Add("Pris", 70);
            listView1.Columns.Add("Aargang", 70);
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
                controller.DeleteDebitor(textBox10.Text);
                ClearTextBoxes();

            }
            else if (dialogResult == DialogResult.No)
            {
                //gør ingenting
            }
        }

        

        private void button6_Click(object sender, EventArgs e)
        {   /*TextBox5 is a ForeignKey and is ReadOnly to avoid conflict 
              TextBox6 is a PrimaryKey with Identity Increment */
            controller.UpdatetDebitor(textBox1.Text,
                                      textBox2.Text,
                                      int.Parse(textBox3.Text),
                                      textBox4.Text,
                                      textBox5.Text,
                                      textBox6.Text,
                                      textBox7.Text,
                                      textBox8.Text,
                                      textBox9.Text
                                      );
            ClearTextBoxes();
        }
        private void button2_Click(object sender, EventArgs e)//search
        {
            /*Needs Error handling for when nothing is typed in textBox10*/
            controller.HentDebitor(textBox10.Text);
            DebitorObj debitorObj = controller.debitor[0];

            textBox1.Text = debitorObj.Navn;
            textBox2.Text = debitorObj.Adresse;
            textBox3.Text = debitorObj.PostNr.ToString();
            textBox4.Text = debitorObj.By;
            textBox5.Text = debitorObj.MedarbejderNr;
            textBox6.Text = debitorObj.DebitorNr;
            textBox7.Text = debitorObj.KundeType;
            textBox8.Text = debitorObj.Tlf;
            textBox9.Text = debitorObj.KundeNr;
            controller.debitor.Clear();
                
        }
        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            controller.FindDebitorRessourceBookinger(textBox6.Text);

            string[] strArr = new string[9];

            for (int i = 0; i <= controller.ressBookList.Count; i++) {

            }
        }
    }
}
