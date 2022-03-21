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
    public class Event
    {
        private int eventId;
        private string eventName;
        private string venue;
        private Date eventDate;
        private int maxAttendees;
        private int numAttendees;
        private string dateCreated;
        private Customer[] attendeeList;

        public Event(int eventId, string name, string venue, Date eventDate, int maxAttendees)
        {
            this.eventId = eventId;
            this.eventName = name;
            this.venue = venue;
            this.eventDate = eventDate;
            this.maxAttendees = maxAttendees;
            numAttendees = 0;
            attendeeList = new Customer[maxAttendees];
            dateCreated = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
        }

        public int getEventId() { return eventId; }
        public string getEventName() { return eventName; }
        public string getVenue() { return venue; }

        public Date getDate() { return eventDate; }
        public int getMaxAttendees() { return maxAttendees; }
        public int getNumAttendees() { return numAttendees; }

        //method to add a customer to the list of attendee once RSVP is done
        public bool addAttendee(Customer c)
        {
            if (numAttendees >= maxAttendees) { return false; }
            attendeeList[numAttendees] = c;
            int curBook = c.getNumBookings();
            curBook++;
            c.setNumBookings(curBook);
            numAttendees++;
            return true;
        }

        //method to find attendee from the list
        private int findAttendee(int custId)
        {
            for (int x = 0; x < maxAttendees; x++)
            {
                if (attendeeList[x].getId() == custId)
                    return x;
            }
            return -1;
        }

        //method to remove attendee from the list
        public bool removeAttendee(int custId)
        {
            int loc = findAttendee(custId);
            if (loc == -1) return false;
            attendeeList[loc] = attendeeList[numAttendees - 1];
            numAttendees--;
            return true;
        }

        //method to get a list of attendees
        public string getAttendees()
        {
            string s = "\nCustomers registered :";
            for (int x = 0; x < numAttendees; x++)
            {
                s = s + "\n" + (x + 1) + ".  " + attendeeList[x].getFirstName() + " " + attendeeList[x].getLastName();
            }
            return s;
        }

        public override string ToString()
        {
            string s = "Event: " + eventId;
            s = s + "\nName:                  " + eventName;
            s = s + "\nVenue:                 " + venue;
            s = s + "\nDate:                  " + eventDate;
            s = s + "\nRegistered Attendees:  " + numAttendees;
            s = s + "\nAvailable spaces:      " + (maxAttendees - numAttendees);
            s = s + getAttendees();
            return s;
        }
    }
}
