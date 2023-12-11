using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace ForTheProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<PhoneNumber> phoneNumbers;
        

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the List and add your sample phone numbers
            phoneNumbers = new List<PhoneNumber>
            {
                new PhoneNumber { Number = "450-444-2312", Type = "Work" },
                new PhoneNumber { Number = "450-312-444", Type = "Home" }
            };

            // Set the List as the data context for the ListBox
            phoneNumberListBox.ItemsSource = phoneNumbers;
        }

        private void AddPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            AddPhoneNumberWindow addPhoneNumberWindow = new AddPhoneNumberWindow();

            
            if (addPhoneNumberWindow.ShowDialog() == true)
            {
                // Retrieve user input from the window
                string phoneNumber = addPhoneNumberWindow.PhoneNumber;
                string phoneType = addPhoneNumberWindow.PhoneType;

                // Create a new PhoneNumber object
                PhoneNumber newPhoneNumber = new PhoneNumber
                {
                    Number = phoneNumber,
                    Type = phoneType,
                    // Set other properties as needed
                };

                // Call the AddPhone method to save it to the database and get the newId
                int newId = AddPhone(newPhoneNumber);

                // Add the new phone number to the List
                phoneNumbers.Add(newPhoneNumber);

                
            }
        }
        



    }
}

