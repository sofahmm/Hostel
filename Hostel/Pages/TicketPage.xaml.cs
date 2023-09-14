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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hostel.Pages
{
    /// <summary>
    /// Логика взаимодействия для TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        public static List<Room> rooms { get; set; }
        public static List<Class> classes { get; set; }
        public TicketPage()
        {
            InitializeComponent();
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
