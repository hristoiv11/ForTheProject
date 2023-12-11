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

namespace ForTheProject
{
    /// <summary>
    /// Interaction logic for AddPhoneNumberWindow.xaml
    /// </summary>
    public partial class AddPhoneNumberWindow : Window
    {
        public string PhoneNumber { get; private set; }
        public string PhoneType { get; private set; }

        public AddPhoneNumberWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Set properties based on user input
            PhoneNumber = phoneNumberTextBox.Text;
            PhoneType = typeTextBox.Text;

            // Close the window and return true to indicate success
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window and return false to indicate cancellation
            DialogResult = false;
        }
    }
}
