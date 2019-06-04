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
    public partial class OpretKunde : Form
    {
        DBController dbc = new DBController();
        public OpretKunde()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbc.InsertDebitor(textBox1.ToString(), 
                textBox2.ToString(), 
                int.Parse(textBox3.ToString()), 
                textBox4.ToString(), 
                textBox5.ToString(),
                textBox6.ToString(),
                textBox7.ToString(),
                textBox8.ToString());
        }
    }
}
