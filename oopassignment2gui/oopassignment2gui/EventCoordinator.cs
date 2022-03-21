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
    public class EventCoordinator
    {
        CustomerManager custMan;
        EventManager eventMan;
        RsvpManager rvManager;

        public EventCoordinator(int custIdSeed, int maxCust, int eventIdSeed, int maxEvents)
        {
            custMan = new CustomerManager(custIdSeed, maxCust);
            eventMan = new EventManager(eventIdSeed, maxEvents);
            rvManager = new RsvpManager(maxCust);
        }

        //customer related methods
        public bool addCustomer(string fname, string lname, string phone)
        {
            return custMan.addCustomer(fname, lname, phone);
        }

        public string customerList()
        {
            return custMan.getCustomerList();
        }

        public string getCustomerInfoById(int id)
        {
            return custMan.getCustomerInfo(id);
        }
        public bool deleteCustomer(int id)
        {
            return custMan.deleteCustomer(id);
        }

        public Customer getCustomer(int cid)
        {
            return custMan.getCustomer(cid);
        }



        // Event related methods
        public bool addEvent(string name, string venue, Date eventDate, int maxAttendee)
        {
            return eventMan.addEvent(name, venue, eventDate, maxAttendee);
        }

        public string eventList()
        {
            return eventMan.getEventList();
        }

        public string getEventInfoById(int id)
        {
            return eventMan.getEventInfo(id);
        }

        public bool customerExist(int cid)
        {
            return custMan.customerExist(cid);
        }

        public bool roomAvailable(int eventId)
        {
            return eventMan.roomAvailable(eventId);
        }

        public Event getEvent(int eid)
        {
            return eventMan.getEvent(eid);
        }
        public bool eventExist(int id)
        {
            return eventMan.eventExists(id);
        }
        // Rvsp related

        public bool makingRsvp(string cName, int eventId)
        {
            return rvManager.makingRsvp(cName, eventId);
        }

        public int getRsvp(int bNum)
        {
            return rvManager.getRsvp(bNum).getRsvpNum();
        }

        public string getRsvpList()
        {
            return rvManager.getRsvpList();
        }
    }
}
