using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace Project_P3L
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        private string connection;
        MySqlConnection conn;
        MySqlCommand cmd;


        public MainWindow()
        {
            InitializeComponent();
            try
            {
                dbConnection();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "Connection Lost");
            }
        }

        public void dbConnection()
        {   //Fungsi untuk koneksi ke database
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
        private void TxtID_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TxtPass_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private bool ValidateLogin(string id, string password)
        {   //Fungsi untuk memvalidasi login
            dbConnection();
            cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM employees WHERE id=@id AND password=@password";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@password", password);

            cmd.Connection = conn;
            MySqlDataReader login = cmd.ExecuteReader();

            return login.Read() ? true : false;
        }


        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {   //Fungsi button untuk login
            string id = txtID.Text;
            string password = txtPass.Text;

            if (id == "" || password == "")
                MessageBox.Show("Please Fill the Field", "Warning");
            else
            {
                bool r = ValidateLogin(id, password);
                if (r)
                {
                    MessageBox.Show("Welcome", "Welcome");
                    conn.Close();
                    Employees window = new Employees();
                    this.Close();
                    window.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Warning");
                    conn.Close();
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {   //Fungsi yang digunakan jika user tidak jadi atau ingin menghapus id dan password
            txtID.Clear();
            txtPass.Clear();
        }
    }
}