using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;
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

namespace HotelApp.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDatabaseData _db;

        public int GuestId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string RoomNumber { get; set; }
        public string RoomType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool CheckedIn { get; set; }

        public Guid ConfirmationNumber { get; set; }

        public MainWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        
        private void searchForReservation_Click(object sender, RoutedEventArgs e)
        {
            List<ReservationModel> result = _db.GetAReservation(searchFieldText.Text);
            resultsList.ItemsSource = result;


        }

        private void Button_Click_CheckIn(object sender, RoutedEventArgs e)
        {
            ReservationModel checkedInResv = _db.CheckInGuest(ConfirmationNumber.ToString()); //for some reason the confirmation number isn't getting passed in here  ?

            List<ReservationModel> result = _db.GetAReservation(searchFieldText.Text);
            resultsList.ItemsSource = result;
        }
    }
}
