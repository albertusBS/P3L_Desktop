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

        private void dbConnection()
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
        private void TxtUser_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TxtPass_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private bool validateLogin(string name, string password)
        {
            cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM employees WHERE name=@user AND password=@password";
            cmd.Parameters.AddWithValue("@user", name);
            cmd.Parameters.AddWithValue("@password", password);
            //cmd.Connection = conn;
            MySqlDataReader login = cmd.ExecuteReader();

            return login.Read() ? true : false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            if (username == "" || password == "")
                MessageBox.Show("Please Fill the Field", "Warning");
            else
            {
                bool r = validateLogin(username, password);
                if (r)
                {
                    MessageBox.Show("Welcome", "Welcome");
                    Window1 window = new Window1();
                    this.Close();
                    window.Show();
                }
                else
                    MessageBox.Show("Invalid Username or Password", "Warning");
            }
        }
    }
}