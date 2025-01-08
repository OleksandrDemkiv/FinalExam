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
        static List<Event> events = new List<Event>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            events = new List<Event>
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

            EventsBox.ItemsSource = events;
        }

        private void EventsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TicketsBox.ItemsSource = (EventsBox.SelectedItem as Event).Tickets;

        }
    }
}