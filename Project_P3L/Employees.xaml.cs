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
    public partial class Employees : Window
    {
        private string connection;
        private MySqlConnection conn;
        private DataTable dt;
        MySqlCommand cmd;

        public Employees()
        {
            InitializeComponent();
            try
            {
                cmd = new MySqlCommand();
                cmd.CommandText = "SELECT * FROM employees";

                dbConnection();

                cmd.Connection = conn;
                dt = new DataTable();
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

        private void TxtBirtdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView selectedRow = dg.SelectedItem as DataRowView;

            if (selectedRow != null)
            {
                txtID.IsEnabled = false;
                txtID.Text = selectedRow["id"].ToString();
                txtName.Text = selectedRow["name"].ToString();
                txtAddress.Text = selectedRow["address"].ToString();
                datePicker.Text = selectedRow["birthdate"].ToString();
                txtPhone.Text = selectedRow["phone_number"].ToString();
                ComBoRole.Text = selectedRow["role"].ToString();
                txtPassword.Text = selectedRow["password"].ToString();
            }
        }

        private void RefreshDataGrid()
        {
            dbConnection();
            cmd = new MySqlCommand("SELECT * FROM employees");

            cmd.Connection = conn;
            dataGrid.Items.Refresh();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            dataGrid.DataContext = dt;
            ClearTextBox();
        }

        private void ClearTextBox()
        {
            txtID.Clear();
            txtID.IsEnabled = true;
            txtName.Clear();
            txtAddress.Clear();
            datePicker.SelectedDate = null;
            txtPhone.Clear();
            ComBoRole.SelectedIndex = 0;
            txtPassword.Clear();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd-MM-yyyy";
            }
        }

        public bool AddEmployees(string id, string name, string address, string birthDate, string phoneNumber, string role, string password)
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
            string birthDate = datePicker.SelectedDate.Value.ToString("yyyy-MM-dd");
            string phoneNumber = txtPhone.Text;
            string role = ((ComboBoxItem)ComBoRole.SelectedItem).Content.ToString();
            string password = txtPassword.Text;

            if (id == "" || name == "" || address == "" || birthDate == "" || phoneNumber == "" || role == "" || role == "-- Select --" || password == "")
                MessageBox.Show("Please fill all the field", "Warning");
            else
            {
                try
                {
                    bool add = AddEmployees(id, name, address, birthDate, phoneNumber, role, password);
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "Duplicate Data");
                }
                
                MessageBox.Show("Successful", "Successful input");

                RefreshDataGrid();
            }
        }

        private bool EditEmployees(string id, string name, string address, string birthDate, string phoneNumber, string role, string password)
        {
            dbConnection();

            cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE employees SET name=@name, address=@address, birthdate=@birthdate, phone_number=@phone_number, role=@role, password=@password WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@birthdate", birthDate);
            cmd.Parameters.AddWithValue("@phone_number", phoneNumber);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@password", password);

            cmd.Connection = conn;

            MySqlDataReader edit = cmd.ExecuteReader();

            return edit.Read() ? true : false;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            string id = txtID.Text;
            string temp = id;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string birthDate = datePicker.SelectedDate.Value.ToString("yyyy-MM-dd");
            string phoneNumber = txtPhone.Text;
            string role = ((ComboBoxItem)ComBoRole.SelectedItem).Content.ToString();
            string password = txtPassword.Text;

            if (id == "" || name == "" || address == "" || birthDate == "" || phoneNumber == "" || role == "" || role == "-- Select --" || password == "")
                MessageBox.Show("Please fill all the field", "Warning");
            else if (id != temp)
                MessageBox.Show("ID employee can't be changed", "Warning");
            else
            {

                bool edit = EditEmployees(id, name, address, birthDate, phoneNumber, role, password);

                MessageBox.Show("Successful Edit", "Successful");

                RefreshDataGrid();
            }
        }

        private bool DeleteEmployees(string id)
        {
            dbConnection();

            cmd = new MySqlCommand();
            cmd.CommandText = "DELETE FROM employees WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Connection = conn;

            MySqlDataReader delete = cmd.ExecuteReader();

            return delete.Read() ? true : false;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string id = txtID.Text;

            if (id == "")
                MessageBox.Show("Please select employee from data table", "Warning");
            else
            {
                bool delete = DeleteEmployees(id);

                MessageBox.Show("Successful Delete", "Successful");

                RefreshDataGrid();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
        }
    }
}