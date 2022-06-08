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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Windows.Threading;
using System.Timers;
using MaterialDesignColors;
namespace P4project
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Click);

            Timer.Interval = new TimeSpan(0, 0, 1);

            Timer.Start();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        private void Timer_Click(object sender, EventArgs e)

        {

            DateTime d;

            d = DateTime.Now;

          

            TimerLabel.Content = d.Hour + " : " + d.Minute + " : " + d.Second;

        }

        private bool VerifyUser(string username, string password)
        {
            con.Open();
            com.Connection= con;
            com.CommandText = "select Status from Users where UserName='" + username + "'and UserPassword='" + password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                if (Convert.ToBoolean(dr["Status"]) == true)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        private void Border_MouseDown(object sender, RoutedEventArgs e)
        {
            
        }
     
    
        
        private void btnLogin_Click_1(object sender, RoutedEventArgs e)

        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }


          if(VerifyUser(txtUsername.Text, txtPassword.Password))
            {
                MessageBox.Show("Login succesfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
                NotesWindow noteswindow = new NotesWindow();
                this.Visibility = Visibility.Hidden;
                noteswindow.Show();
            }
            else
            {
                MessageBox.Show("Username or login is incorrect!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            this.Visibility = Visibility.Hidden;
            registration.Show();
        }

       
    }
}
