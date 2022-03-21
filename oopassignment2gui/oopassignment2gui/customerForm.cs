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
using System.Text.RegularExpressions;

namespace oopassignment2gui
{
    public partial class customerForm : Form
    {
        menuForm m1;
        EventCoordinator ec1;
        
        public customerForm()
        {
            InitializeComponent();
        }

        public customerForm(menuForm m, EventCoordinator ec)
        {
            InitializeComponent();
            m1 = m;
            ec1 = ec;
        }

        private void customerForm_Load(object sender, EventArgs e)
        {

        }

        //event for cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            m1.Show();
        }

        //event for reset button
        private void btnReset_Click(object sender, EventArgs e)
        {
            errFname.Text = "";
            errLname.Text = "";
            errPhone.Text = "";
            lblMsg.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtPhone.Text = "";
        }

        //event for add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fname, lname, phone;
            errFname.Text = "";
            errLname.Text = "";
            errPhone.Text = "";
            lblMsg.Text = "";
            while(IsAlphabets(txtFname, errFname) != null && IsAlphabets(txtLname, errLname) != null && formatPhoneNumber(txtPhone, errPhone) != null)
            {
                fname = IsAlphabets(txtFname, errFname);
                lname = IsAlphabets(txtLname, errLname);
                phone = formatPhoneNumber(txtPhone, errPhone);
                if (ec1.addCustomer(fname, lname, phone))
                {
                    lblMsg.Text = "Customer successfully added!";
                    menuForm m2 = new menuForm(this, ec1);
                    
                }
                else 
                { 
                    lblMsg.Text = "Customer was not added!";
                }
                break;
                
            }
            txtFname.Text = "";
            txtLname.Text = "";
            txtPhone.Text = "";
            
        }

        public static int getIntChoice(TextBox t, Label l)
        {
            int choice;
            if (!int.TryParse(t.Text, out choice))
            {
                l.Text = "Please enter an integer:";
                t.Clear();
                t.Focus();
                return 0;
            }
            return choice;
        }
        public static string IsAlphabets(TextBox t, Label l)
        {
            string value = t.Text;
            Regex r = new Regex("^[a-zA-Z ]+$");
            if (!r.IsMatch(value))
            {
                l.Text = "Please use alphabets and space only:";
                t.Clear();
                t.Focus();
                return null;
            }
            return value;

        }

        //validates if the input string is valid as a phone number
        public static string formatPhoneNumber(TextBox t, Label l)
        {
            string ph = t.Text;
            //checks if it's null or contains any non-digits
            if (string.IsNullOrWhiteSpace(ph) || !Regex.IsMatch(ph, @"^[\d\-]+$") || Regex.IsMatch(ph, @"^[a-zA-Z]") || ph.Length < 10 || ph.Length > 12)
            {
                l.Text = "Enter in the format of ###-###-####";
                t.Clear();
                t.Focus();
                return null;
            }
            //checks if it's in the format: ###-###-####
            if (Regex.IsMatch(ph, @"^(\d{3}-\d{3}-\d{4})$"))
            {
                //returned if correct
                return ph;
            }
            if (ph.Length == 10)
            {
                return string.Format("{0:###-###-####}", double.Parse(ph));
            }
            return ph;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
