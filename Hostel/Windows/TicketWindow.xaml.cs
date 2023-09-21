using Hostel.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hostel.Windows
{
    /// <summary>
    /// Логика взаимодействия для TicketWindow.xaml
    /// </summary>
    public partial class TicketWindow : Window
    {
        public static List<Room> rooms { get; set; }
        public static List<Class> classes { get; set; }

        Client client1 = new Client();
        public TicketWindow(Client client)
        {
            InitializeComponent();

            client1 = client;
            NameTb.Text = client1.lastname + " " + client1.FirstName + " " + client1.Patronymic;

            rooms = new List<Room>
                (DbConnection.prog320Entities.Room.ToList());
            classes = new List<Class>
                (DbConnection.prog320Entities.Class.ToList());
            this.DataContext = this;
        }

        private void ClassesCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Class cl = ClassesCb.SelectedItem as Class;
            RoomsCb.ItemsSource = new List<Room>
                (DbConnection.prog320Entities.Room.
                Where(l => l.IdClass == cl.ID).ToList());
        }
    }
}
