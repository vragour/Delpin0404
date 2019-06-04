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
    public partial class OversigtRessAfd : Form
    {
        
        private DBController dbc = new DBController();
       
        public OversigtRessAfd()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Navn", 75);
            listView1.Columns.Add("rnr", 50);
            listView1.Columns.Add("Maerke", 150);
            listView1.Columns.Add("Pris", 50);
            listView1.Columns.Add("Adresse", 150);
            listView1.Columns.Add("PostNr", 50);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dbc.afdRessObjs.Count == 0)
            {
                Console.WriteLine("the list is empty");//test code. This should be a type of dialog.
            }
            else
            {
                string[] arr = new string[6];

                for (int i = 0; i < dbc.afdRessObjs.Count; i++)
                {
                    arr[0] = dbc.afdRessObjs[i].Name;
                    arr[1] = dbc.afdRessObjs[i].ResNr.ToString();
                    arr[2] = dbc.afdRessObjs[i].Maerke;
                    arr[3] = dbc.afdRessObjs[i].Pris.ToString();
                    arr[4] = dbc.afdRessObjs[i].Adresse;
                    arr[5] = dbc.afdRessObjs[i].PostNr.ToString();

                    ListViewItem itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                }
                dbc.afdRessObjs.Clear();//Clearing the list when we are done to avoid side effects
            }
            
        }
    }
}
