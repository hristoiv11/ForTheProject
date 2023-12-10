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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber phoneNumber = new PhoneNumber();
            phoneNumber.Number = phoneNumberTextBox.Text;
            phoneNumber.Type = typeTextBox.Text;

            HandlerPhoneNumber pn = HandlerPhoneNumber.Instance;
            pn.AddPhone(phoneNumber);
            Close();
        }
    }
}
