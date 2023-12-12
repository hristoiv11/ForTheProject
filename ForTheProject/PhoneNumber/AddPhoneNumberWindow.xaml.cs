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

        public AddPhoneNumberWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber newPhone = new PhoneNumber();
            newPhone.Number = phoneNumberTextBox.Text;
            newPhone.Type = typeTextBox.Text;
            

            HandlerPhoneNumber db = HandlerPhoneNumber.Instance;
            db.AddPhone(newPhone);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window and return false to indicate cancellation
            DialogResult = false;
        }
    }
}
