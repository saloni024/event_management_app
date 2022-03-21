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
    public class EventManager
    {
        private static int currentEventId;
        private int maxEvents;
        private int numEvents;
        private Event[] eventList;

        public EventManager(int idSeed, int max)
        {
            currentEventId = idSeed;
            maxEvents = max;
            numEvents = 0;
            eventList = new Event[maxEvents];
        }

        public bool addEvent(string name, string venue, Date eventDate, int maxAttendees)
        {
            if (numEvents >= maxEvents) { return false; }

            for (int x = 0; x < numEvents; x++)
            {
                if (eventList[x].getVenue().ToLower().Equals(venue.ToLower()) && eventList[x].getDate().day == eventDate.day && eventList[x].getDate().month == eventDate.month && eventList[x].getDate().year == eventDate.year)
                {
                    return false;
                }

            }

            Event e = new Event(currentEventId, name, venue, eventDate, maxAttendees);
            eventList[numEvents] = e;
            numEvents++;
            currentEventId++;
            return true;
        }

        private int findEvent(int eid)
        {
            for (int x = 0; x < numEvents; x++)
            {
                if (eventList[x].getEventId() == eid)
                    return x;
            }
            return -1;
        }

        public bool eventExists(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return false; }
            return true;
        }

        public Event getEvent(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return null; }
            return eventList[loc];
        }

        public bool deleteEvent(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return false; }
            eventList[loc] = eventList[numEvents - 1];
            numEvents--;
            return true;
        }
        public string getEventInfo(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return "There is no event with id " + eid + "."; }
            return eventList[loc].ToString();
        }
        public string getEventList()
        {
            string s = "Event List: ";
            s += "\nEvent Id   \t Event Name   \t   Venue";
            for (int x = 0; x < numEvents; x++)
            {
                s = s + "\n" + eventList[x].getEventId() + "           \t                    " + eventList[x].getEventName() + "              \t        " + eventList[x].getVenue();
            }
            return s;
        }

        //checks if there is a room for customer in the event
        public bool roomAvailable(int id)
        {
            Event x = getEvent(id);
            if (x.getMaxAttendees() > x.getNumAttendees())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
