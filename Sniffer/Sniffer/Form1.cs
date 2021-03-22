using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sniffer
{
    public partial class Form1 : Form
    {
        string itemNumber = "", time = "", source = "", sourcePort = "", destination = "", destinationPort = "", protocol = "", packageSize = "";
        public Form1()
        {
            InitializeComponent();
            addItems();
        }

        private void addItems()
        {
            listView1.Items.Add("Test1");
            listView1.Items.Add("Test2");
            listView1.Items.Add("Test3");
            listView1.Items.Add("Test4");
            listView1.Items.Add("Test5");
            listView1.Items.Add("Test6");
            listView1.Items.Add("Test7");
            listView1.Items.Add("Test8");
            listView1.Items.Add("Test9");
            listView1.Items.Add("Test10");
            listView1.Items.Add("Test11");
            listView1.Items.Add("Test12");
            listView1.Items.Add("Test13");
            listView1.Items.Add("Test14");
            listView1.Items.Add("Test15");
            listView1.Items.Add("Test16");
            listView1.Items.Add("Test17");
            listView1.Items.Add("Test18");
        }
    


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
