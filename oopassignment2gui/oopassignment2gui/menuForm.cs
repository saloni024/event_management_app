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
    public partial class menuForm : Form
    {
        Form1 f1;
        customerForm cf1;
        eventForm ef1;
        EventCoordinator ec1;
        private int custId;

        public int getCustId()
        {
            return custId;
        }

        public menuForm()
        {
            InitializeComponent();
            hideMethods();

        }
        public menuForm(Form1 f, EventCoordinator ec)
        {
            InitializeComponent();
            f1 = f;
            ec1 = ec;
            hideMethods();
        }

        public menuForm(customerForm cf, EventCoordinator ec)
        {
            InitializeComponent();
            cf1 = cf;
            ec1 = ec;
            hideMethods();
        }

        public menuForm(eventForm ef, EventCoordinator ec)
        {
            InitializeComponent();
            ef1 = ef;
            ec1 = ec;
            hideMethods();
        }

        private void menuForm_Load(object sender, EventArgs e)
        {

        }

        //event for home button
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            f1.Show();
        }

        //event for Customer->add option in menu bar
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            customerForm cf1 = new customerForm(this, ec1);
            cf1.Show();
        }

        //event for Event->add option in menu bar
        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            eventForm ef1 = new eventForm(this, ec1);
            ef1.Show();
        }

        //event for Customer->view->list option in menu bar
        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideMenu();
            lblCustList.Show();
            lblCustList.Text = ec1.customerList();
        }

        //event for return button
        private void btnReturn_Click(object sender, EventArgs e)
        {
            hideMethods();
            showMenu();

        }

        //event for Event->view->list option in menu bar
        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hideMenu();
            lblEventList.Show();
            lblEventList.Text = ec1.eventList();
        }

        //event for Customer->view->details option in menu bar
        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {

            hideMenu();
            lblCustList.Show();
            lblId.Show();
            txtSearch.Show();
            btnCusSearch.Show();
            lblCustList.Text = ec1.customerList();
        }

        //event for Event->view->details option in menu bar
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideMenu();
            lblEventList.Show();
            lblId.Show();
            txtSearch.Show();
            btnEventSearch.Show();
            lblEventList.Text = ec1.eventList();
        }

        //event for 'Go!' button in Customer details window
        private void btnCusSearch_Click(object sender, EventArgs e)
        {
            int id;
            if (Int32.TryParse(txtSearch.Text, out id))
            {
                lblCustList.Text = "";
                lblCustList.Text = ec1.getCustomerInfoById(id);
                txtSearch.Text = "";
            }
        }

        //event for 'Go!' button in Event details window
        private void btnEventSearch_Click(object sender, EventArgs e)
        {
            int id;
            if (Int32.TryParse(txtSearch.Text, out id))
            {
                lblEventList.Text = "";
                lblEventList.Text = ec1.getEventInfoById(id);
                txtSearch.Text = "";
            }

        }

        //method that hides and shows the controls
        public void hideMethods()
        {
            btnReturn.Hide();
            lblCustList.Hide();
            lblCustList.Text = "";
            lblEventList.Hide();
            lblEventList.Text = "";
            lblId.Hide();
            txtSearch.Hide();
            txtSearch.Text = "";
            btnCusSearch.Hide();
            btnEventSearch.Hide();
            btnDelete.Hide();
            btnGetCust.Hide();
            btnGetEvent.Hide();
            this.BackgroundImage = Properties.Resources.blue;
        }

        //method that hides and shows the controls
        public void hideMenu()
        {
            lblTitle.Hide();
            lblTitle2.Hide();
            btnHome.Hide();
            menuStrip1.Hide();
            this.BackColor = System.Drawing.Color.AliceBlue;
            btnReturn.Show();
        }

        //method that hides and shows the controls
        public void showMenu()
        {
            lblTitle.Show();
            lblTitle2.Show();
            btnHome.Show();
            menuStrip1.Show();
            this.BackgroundImage = Properties.Resources.blue;
            btnReturn.Hide();
        }

        //event for Customer->delete option in menu bar
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideMenu();
            lblCustList.Show();
            lblId.Show();
            txtSearch.Show();
            btnDelete.Show();
            lblCustList.Text = ec1.customerList();
        }

        //event for 'Go!' button in Delete customer window
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id;
            if (Int32.TryParse(txtSearch.Text, out id))
            {
                lblEventList.Text = "";
                if (ec1.deleteCustomer(id))
                {
                    lblCustList.Text = "Customer with id " + id + " deleted!";
                }
                else
                {
                    lblCustList.Text = "Customer with id " + id + " was not found!";
                }
                txtSearch.Text = "";
            }
        }

        //event for Registration->Rsvp for event option in menu bar
        private void rSVPForEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideMenu();
            lblCustList.Show();
            lblId.Show();
            txtSearch.Show();
            btnGetCust.Show();
            lblCustList.Text = ec1.customerList();
        }

        //event for 'Go!' button in rsvp customer selection window
        private void btnGetCust_Click(object sender, EventArgs e)
        {
            
            if (Int32.TryParse(txtSearch.Text, out custId) && ec1.customerExist(custId))
            {
                lblCustList.Text = "";
                lblCustList.Hide();
                lblEventList.Show();
                lblEventList.Text = ec1.eventList();
                btnGetCust.Hide();
                btnGetEvent.Show();
                txtSearch.Text = "";
            }
            else
            {
                lblCustList.Text = "";
                lblCustList.Text = "This customer does not exist!\n";
                txtSearch.Text = "";
                lblCustList.Text += ec1.customerList();
            }
        }

        //event for 'Go!' button in rsvp event selection window
        private void btnGetEvent_Click(object sender, EventArgs e)
        {
            int eventId;
            if (Int32.TryParse(txtSearch.Text, out eventId) && ec1.eventExist(eventId))
            {
                if (ec1.roomAvailable(eventId))
                {
                    lblCustList.Hide();
                    lblEventList.Show();
                    ec1.getEvent(eventId).addAttendee(ec1.getCustomer(custId));
                    ec1.makingRsvp(ec1.getCustomer(custId).getFirstName() + " " + ec1.getCustomer(custId).getLastName(), eventId);
                    lblEventList.Text = "";
                    lblEventList.Text = "Your registration is created successfully!";
                    btnGetCust.Hide();
                    btnGetEvent.Show();
                    txtSearch.Text = "";
                }
                else
                {
                    lblCustList.Hide();
                    lblEventList.Show();
                    lblEventList.Text = "";
                    lblEventList.Text = "This event is full!\n";
                    btnGetCust.Hide();
                    btnGetEvent.Show();
                    txtSearch.Text = "";
                    lblEventList.Text += ec1.eventList();
                }
            }
            else
            {
                lblCustList.Hide();
                lblEventList.Show();
                lblEventList.Text = "";
                lblEventList.Text = "This event does not exist!\n";
                btnGetCust.Hide();
                btnGetEvent.Show();
                txtSearch.Text = "";
                lblEventList.Text += ec1.eventList();
            }

        }

        //event for Registration->view option in menu bar
        private void viewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            hideMenu();
            lblCustList.Text = "";
            lblCustList.Show();
            lblCustList.Text = ec1.getRsvpList();
        }
    }
}