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

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ConfirmationNum { get; set; }

        public MainWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        
        private void searchForReservation_Click(object sender, RoutedEventArgs e)
        {
            List<ReservationModel> result = _db.GetAReservation(searchFieldText.Text);
         
        }
    }
}
