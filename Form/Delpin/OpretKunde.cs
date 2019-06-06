using System;
using System.Windows.Forms;
using Backend;

namespace Delpin
{
    public partial class OpretKunde : Form
    {
        DBController dbc = new DBController();
        public OpretKunde()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbc.InsertDebitor(
                textBox1.Text, 
                textBox2.Text, 
                int.Parse(textBox3.Text),
                textBox4.Text, 
                textBox6.Text,
                textBox7.Text,
                textBox8.Text);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }
    }
}
