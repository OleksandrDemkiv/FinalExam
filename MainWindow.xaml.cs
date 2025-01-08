using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static FinalExam.Event;

namespace FinalExam // https://github.com/OleksandrDemkiv/FinalExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // all the events and tickets
        static List<Event> events = new List<Event>
        {
            new Event(
                "Oasis Croke Park", new DateTime(2025, 06, 20), EventType.Music,
                new List<Ticket>
                {
                    new Ticket("Early Bird", 100m, 100),
                    new VIPTicket("Ticket and Hotel Package", 150m, 100, "4* hotel", 100m),
                }
            ),

            new Event(
                "Electric Picnic", new DateTime(2025, 08, 20), EventType.Music,
                new List<Ticket>
                {
                    new Ticket("Platinium", 150m, 200),
                    new VIPTicket("Weekend Ticket", 200m, 100, "with camping", 100m)

                }
            )
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            events.Sort(); // sort events by date

            // set events item source
            EventsBox.ItemsSource = events;
        }

        private void EventsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Event selectedEvent = EventsBox.SelectedItem as Event;
           
            if (selectedEvent != null) // if any event selected
            {
                TicketsBox.ItemsSource = selectedEvent.Tickets;
            }
            else
            {
                TicketsBox.ItemsSource = null; // or handle the null case appropriately
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) // when book button is clicked
        {
            int noOfTickets;

            // check for number of tickets
            if (!int.TryParse(NoOfTickets.Text, out noOfTickets) || noOfTickets <= 0)
            {
                MsgLabel.Content = "Please enter a valid number of tickets";
                MsgLabel.Foreground = Brushes.Red;
                return;
            }

            // check for selected event and ticket
            if (EventsBox.SelectedItem == null || TicketsBox.SelectedItem == null)
            {
                MsgLabel.Content = "Please select an event and ticket type";
                MsgLabel.Foreground = Brushes.Red;
                return;
            }

            // check for available tickets
            if ((TicketsBox.SelectedItem as Ticket).AvailableTickets < noOfTickets)
            {
                MsgLabel.Content = "Not enough tickets available";
                MsgLabel.Foreground = Brushes.Red;
                return;
            }

            // if everything is ok, proceed with booking
            // update available tickets and display message
            (TicketsBox.SelectedItem as Ticket).AvailableTickets -= noOfTickets;
            MsgLabel.Content = $"{(TicketsBox.SelectedItem as Ticket).Name}, {noOfTickets}\ntickets booked successfully";
            MsgLabel.Foreground = Brushes.Green;

            TicketsBox.Items.Refresh(); // updating the list box immediately
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EventsBox == null) return; // crash fix on load

            // first checing for emptying the search box and returning all events
            if (SearchBox.Text == "")
            {
                EventsBox.ItemsSource = events;
                return;
            }

            // new list for searched events
            List<Event> SearchedEvents = new List<Event>();

            // searching for events
            foreach (Event ev in events)
            {
                if (ev.Name.ToLower().Contains(SearchBox.Text.ToLower()))
                {
                    SearchedEvents.Add(ev);
                }
            }

            // setting the searched events
            EventsBox.ItemsSource = SearchedEvents;
        }
    }
}