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
    public class RsvpManager
    {
        private int idSee;
        private int numCustomer;
        private int maxCustomers;
        private Rsvp[] RsvpList;


        public RsvpManager(int max)
        {
            idSee = 1;
            numCustomer = 0;
            maxCustomers = max;
            RsvpList = new Rsvp[maxCustomers];
        }

        //method to find RSVP for customer using rsvpId
        public int findRsvp(int rNum)
        {
            for (int i = 1; i < numCustomer; i++)
            {
                if (RsvpList[i].getRsvpNum() == i)
                {
                    return i;
                }
            }
            return -1;
        }

        //method to get rsvp for customer using rsvpId
        public Rsvp getRsvp(int rNum)
        {
            int num = findRsvp(rNum);
            if (num == -1) { return null; }
            return RsvpList[num];
        }

        //method to create RSVP for customer
        public bool makingRsvp(string cName, int eventId)
        {
            if (numCustomer >= maxCustomers) { return false; }
            {
                Rsvp temp = new Rsvp(idSee, cName, eventId);
                RsvpList[numCustomer] = temp;
                numCustomer++;
                idSee++;
                return true;
            }
        }

        //generates a list of RSVPs
        public string getRsvpList()
        {
            string s = "Rsvp List: " + "\nRsvp Number         \tDate             \t   Customer Name   \t   Event Id";

            for (int x = 0; x < numCustomer; x++)
            {
                s = s + "\n" + RsvpList[x].getRsvpNum() + "                   \t" + RsvpList[x].getRsvpDate()
                    + "        \t   " + RsvpList[x].getCustomerName() + "   \t   " + RsvpList[x].getEventId();
            }
            return s;
        }
    }
}
