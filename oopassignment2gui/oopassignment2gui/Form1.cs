//Durga Sutharsan - 101285544
//Jorge De La Cruz - 101248516
//Juan Consuegra - 101216670
//Saloni Jagdishbhai Prajapati - 101283741

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oopassignment2gui
{
    
    public partial class Form1 : Form
    {

        EventCoordinator ec1;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(EventCoordinator ec)
        {
            InitializeComponent();
            ec1 = ec;
        }

        //Event for 'Click here to begin!' button
        public void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuForm m = new menuForm(this, ec1);
            m.Show();
        }

        //Event for exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    
}
