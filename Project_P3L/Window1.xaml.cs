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

        private bool AddEmployee(string id, string name, string address, string date, string phoneNumber, string role, string password)
        {
            cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO employees VAlUES(@id, @name, @address, @birthdate, @phone, @role, @password;";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@birthdate", date);
            cmd.Parameters.AddWithValue("@phone", phoneNumber);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@password", password);
            MySqlDataReader addEmployee = cmd.ExecuteReader();

            return addEmployee.Read() ? true : false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}