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
using MySql.Data.MySqlClient;

namespace Project_P3L
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MySqlCommand cmd;
        public Window1()
        {
            InitializeComponent();
        }

        private void TextID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextAddress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBirthdate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextPhone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string birthdate = txtBirthdate.Text;
            string phoneNumber = txtPhone.Text;
            string role = ;
            string password;
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}