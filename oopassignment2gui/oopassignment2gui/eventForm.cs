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
    
    public partial class eventForm : Form
    {
        menuForm m1;
        EventCoordinator ec1;
        public eventForm()
        {
            InitializeComponent();
        }

        public eventForm(menuForm m, EventCoordinator ec)
        {
            InitializeComponent();
            m1 = m;
            ec1 = ec;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //event for reset button
        private void btnReset_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            txtEvent.Text = "";
            txtVenue.Text = "";
            txtMaxAtt.Text = "";
            txtHour.Text = "";
            txtMin.Text = "";
        }

        //event for cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            m1.Show();
        }

        //event for add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            string eventName, venue;
            Date eventDate;
            int maxAttendees;
            int day, month, year, hour, minute;

            eventName = txtEvent.Text;
            venue = txtVenue.Text;

            string date = dtpDate.Text;
            string[] array = date.Split(' ');
            string[] newDate = array[1].Split(',');

            day = Convert.ToInt32(newDate[0]);
            month = 1;
            year = Convert.ToInt32(array[2]);
            
            if(array[0] == "January") { month = 1; }
            else if(array[0] == "February") { month = 2; }
            else if (array[0] == "March") { month = 3; }
            else if (array[0] == "April") { month = 4; }
            else if (array[0] == "May") { month = 5; }
            else if (array[0] == "June") { month = 6; }
            else if (array[0] == "July") { month = 7; }
            else if (array[0] == "August") { month = 8; }
            else if (array[0] == "September") { month = 9; }
            else if (array[0] == "October") { month = 10; }
            else if (array[0] == "November") { month = 11; }
            else if (array[0] == "December") { month = 12; }

            if (Int32.TryParse(txtHour.Text, out hour) && Int32.TryParse(txtMin.Text, out minute) && Int32.TryParse(txtMaxAtt.Text, out maxAttendees))
            {
                eventDate = new Date(day, month, year, hour, minute);
                if(ec1.addEvent(eventName, venue, eventDate, maxAttendees))
                {
                    lblMsg.Text = "Event successfully added!";
                }
                else
                {
                    lblMsg.Text = "Event was not added";
                }

            }
            else
            {
                lblMsg.Text = "Please enter integer for no. of attendees, hour and minute";
            }
            txtEvent.Text = "";
            txtVenue.Text = "";
            txtMaxAtt.Text = "";
            txtHour.Text = "";
            txtMin.Text = "";

        }

        private void eventForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
