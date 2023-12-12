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
    /// Interaction logic for PhoneNumberDetailsWindow.xaml
    /// </summary>
    public partial class PhoneNumberDetailsWindow : Window
    {
        PhoneNumber phoneNumber;
        public PhoneNumberDetailsWindow(PhoneNumber phoneNumber)
        {
            InitializeComponent();
            this.phoneNumber = phoneNumber;

            //Display the user

            NumberTextBox.Text = phoneNumber.Number;
            TypeTextBox.Text = phoneNumber.Number;
            
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            UpdatePhoneNumberWindow updatephoneNumber = new UpdatePhoneNumberWindow(phoneNumber);
            updatephoneNumber.ShowDialog();
            Close();
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
