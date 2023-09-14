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
using Hostel.DB;

namespace Hostel.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public static List<Room> rooms { get; set; }
        public static List<Class> classes { get; set; }
        public static List<Client> clients { get; set; }
        public MainMenuPage()
        {
            InitializeComponent();
            rooms = new List<Room>
                (DbConnection.prog320Entities.Room.ToList());
            classes = new List<Class>
                (DbConnection.prog320Entities.Class.ToList());
            clients = new List<Client>(DbConnection.prog320Entities.Client.ToList());
            this.DataContext = this;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //Client client = new Client();


            if(MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new TicketPage());
            }

            

            //client.FirstName = FirtsNameTb.Text.Trim();
            //client.lastname = NameTb.Text.Trim();
            //client.Patronymic = PatronymicTb.Text.Trim();
            //client.Birthday = BdayDp.SelectedDate;
            //client.PassportData = PassportTb.Text.Trim();
            //client.PhoneNumber = PhoneTb.Text.Trim();
            //client.Email = EmailTb.Text.Trim();



            //DbConnection.prog320Entities.Client.Add(client);
            //DbConnection.prog320Entities.SaveChanges();
        }
    }
}
