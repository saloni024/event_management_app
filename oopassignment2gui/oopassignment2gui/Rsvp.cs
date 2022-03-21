//Durga Sutharsan - 101285544
//Jorge De La Cruz - 101248516
//Juan Consuegra - 101216670
//Saloni Jagdishbhai Prajapati - 101283741

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopassignment2gui
{
    public class Rsvp
    {
        private int rsvpNumber;
        private string rsvpDate;
        private string customerName;
        private int eventId;

        //constructor for RSVP class

        public Rsvp(int rsvpNum, string cName, int idNum)
        {
            rsvpNumber = rsvpNum;
            rsvpDate = DateTime.Now.ToString(@"MM/dd/yyyy h:mm tt");
            customerName = cName;
            eventId = idNum;
        }


        //getters and setters
        public int getRsvpNum()
        {
            return rsvpNumber;
        }
        public string getRsvpDate()
        {
            return rsvpDate;
        }
        public string getCustomerName()
        {
            return customerName;
        }
        public int getEventId()
        {
            return eventId;
        }

        //toString method for RSVP class
        public string toString()
        {
            string s = "Rsvp Numer:   " + rsvpNumber;
            s = s + "\nRsvp Date:     " + rsvpDate;
            s = s + "\nCustomer Name: " + customerName;
            s = s + "\nEvent Id:      " + eventId;
            return s;
        }
    }
}
