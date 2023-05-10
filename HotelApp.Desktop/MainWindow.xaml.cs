using HotelAppLibrary.Databases;
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
            //check to see which of the text boxes have text. Based on the ones that have text in them, use one of the following methods:
            //firs name filled in:
            _db.GetAReservation(firstNameText.Text);
            //first and last name filled in:
            _db.GetAReservation(firstNameText.Text, lastNameText.Text);
            //last name filled in:
            _db.GetAReservation(lastNameText.Text);
            //confirmation number filled in:
            _db.GetAReservation(confirmationNumText.Text);
            //first name and confirmation number 
            _db.GetAReservation(firstNameText.Text, confirmationNumText.Text);
            //last name and confirmation number:
            _db.GetAReservation(lastNameText.Text, confirmationNumText.Text);
            //all 3:
            _db.GetAReservation(firstNameText.Text, lastNameText.Text, confirmationNumText.Text);
        }
    }
}
