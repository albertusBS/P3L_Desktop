using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class AddEmployees : Window
    {
        private string connection;
        private MySqlConnection conn;
        MySqlCommand cmd;

        public AddEmployees()
        {
            InitializeComponent();
            try
            {
                cmd = new MySqlCommand();
                cmd.CommandText = "SELECT * FROM employees";

                dbConnection();

                cmd.Connection = conn;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();

                dataGrid.DataContext = dt;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "Connection Lost");
            }catch(System.InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
            }
            catch(MySql.Data.Types.MySqlConversionException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void dbConnection()
        {
            try
            {
                connection = "SERVER=localhost;DATABASE=pet_shop;UID=root;PASSWORD=;"; //Database Localhost
                //connection = "SERVER=192.168.19.140;DATABASE=9152;UID=pp9152;PASSWORD=9152;"; //Database Web Server Atma
                conn = new MySqlConnection(connection);
                conn.Open();
            }
            catch
            {
                throw;
            }
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


        private void TextPhone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var ComboBox = sender as ComboBox;
            //string value = ComboBox.SelectedItem as string;
        }

        private void TextPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public bool addEmployees(string id, string name, string address, string birthDate, string phoneNumber, string role, string password)
        {
            dbConnection();
            cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO employees(id, name, address, birthdate, phone_number, role, password) VALUES (@id,@name,@address,@birthdate,@phone_number,@role,@password)";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@birthdate", birthDate);
            cmd.Parameters.AddWithValue("@phone_number", phoneNumber);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@password", password);

            cmd.Connection = conn;

            MySqlDataReader add = cmd.ExecuteReader();
            return add.Read() ? true : false;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string birthDate = txtBirthdate.SelectedDate.Value.ToShortDateString();
            string phoneNumber = txtPhone.Text;
            string role = ((ComboBoxItem)ComBoRole.SelectedItem).Content.ToString();
            string password = txtPassword.Text;

            if (id == "" || name == "" || address == "" || birthDate == "" || phoneNumber == "" || role == "" || role == "-- Select --" || password == "")
                MessageBox.Show("Please fill all the field", "Warning");
            else
            {
                bool a = addEmployees(id, name, address, birthDate, phoneNumber, role, password);
                if (a)
                {
                    MessageBox.Show("Successful", "Successful input");
                    conn.Close();
                }
                ClearTextBox();
            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
        }

        private void ClearTextBox()
        {
            txtID.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
        }
    }
}