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
using Hostel.Windows;

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
           

            var dcvd = FirtsNameTb.Text + " " + NameTb.Text + " " + PatronymicTb.Text
                + " " + BdayDp.SelectedDate + " " + PassportTb.Text + " " + PhoneTb.Text;

            

            if (MessageBox.Show(dcvd, "Проверьте корректность введенных данных", MessageBoxButton.YesNo) 
                == MessageBoxResult.Yes)
            {
                Client client = new Client();

                client.FirstName = FirtsNameTb.Text.Trim();
                client.lastname = NameTb.Text.Trim();
                client.Patronymic = PatronymicTb.Text.Trim();
                client.Birthday = BdayDp.SelectedDate;
                client.PassportData = PassportTb.Text.Trim();
                client.PhoneNumber = PhoneTb.Text.Trim();
                client.Email = EmailTb.Text.Trim();

                DbConnection.prog320Entities.Client.Add(client);
                DbConnection.prog320Entities.SaveChanges();

                ClientsLv.ItemsSource = new List<Client>(DbConnection.prog320Entities.Client.ToList());
            }

            
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClientsLv.ItemsSource = new List<Client>(DbConnection.prog320Entities.Client.
                Where(i => i.PassportData.StartsWith(SearchTb.Text)
                || i.lastname.StartsWith(SearchTb.Text)).ToList());
        }

        private void ClientsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client client = 
                ClientsLv.SelectedItem as Client;
            TicketWindow ticketWindow = 
                new TicketWindow(client);
            ticketWindow.Show();    
        }
    }
}
