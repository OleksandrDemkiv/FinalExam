using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    internal class Event : IComparable<Event>
    {
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public List<Ticket> Tickets { get; set; }

        public enum EventType
        {
            Music,
            Comedy,
            Theatre
        }

        public EventType TypeOfEvent { get; set; }

        // compare method for sorting
        public int CompareTo(Event other)
        {
            return EventDate.CompareTo(other.EventDate);
        }

        // override ToString method for displaying
        public override string ToString()
        {
            return $"{Name} - {EventDate:dd/MM/yyyy}";
        }

        // main constructor
        public Event(string name, DateTime eventDate, EventType typeOfEvent, List<Ticket> tickets)
        {
            Name = name;
            EventDate = eventDate;
            TypeOfEvent = typeOfEvent;
            Tickets = tickets;
        }
    }
}
