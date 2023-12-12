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
    /// Interaction logic for UpdatePhoneNumberWindow.xaml
    /// </summary>
    public partial class UpdatePhoneNumberWindow : Window
    {
        PhoneNumber phoneNumber2;
        public UpdatePhoneNumberWindow(PhoneNumber phoneNumber)
        {
            this.phoneNumber2 = phoneNumber;
            InitializeComponent();
            phoneNumberTextBox.Text = phoneNumber.Number;
            typeTextBox.Text = phoneNumber.Type;

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            phoneNumber2.Number = phoneNumberTextBox.Text;
            phoneNumber2.Type = typeTextBox.Text;

            HandlerPhoneNumber pn = HandlerPhoneNumber.Instance;
            pn.UpdatePhone(phoneNumber2);
            Close();

        }
    }
}
