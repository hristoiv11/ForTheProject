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
        HandlerPhoneNumber db = HandlerPhoneNumber.Instance;
         List<PhoneNumber> phoneNumbers;
        

        public MainWindow()
        {
            InitializeComponent();
            RefreshhAllPhoneNumberList();

            
        }

        private void RefreshhAllPhoneNumberList()
        {
            AllPhoneNumberDataGrid.ItemsSource = null;
            phoneNumbers = db.ReadAllPhoneNumbers();
            AllPhoneNumberDataGrid.ItemsSource = phoneNumbers;
        }

        private void AllPhoneNumberGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PhoneNumber phoneNumber = (PhoneNumber)AllPhoneNumberDataGrid.SelectedItem;

            if (phoneNumber != null)
            {
                PhoneNumberDetailsWindow personDetailsWindow = new PhoneNumberDetailsWindow(phoneNumber);
                personDetailsWindow.ShowDialog();
                RefreshhAllPhoneNumberList();
            }
        }

        private void AddPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            AddPhoneNumberWindow addPhoneNumberWindow = new AddPhoneNumberWindow();

            
            addPhoneNumberWindow.ShowDialog();
            RefreshhAllPhoneNumberList();
        }

        private void AllReferencesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddEducation_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddReference_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllEducationGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ReferencesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

