using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
namespace P4project
{
    /// <summary>
    /// Logika interakcji dla klasy Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {

        SqlConnection con = new SqlConnection(@"Server=LAPTOP-I6T122HQ;Database=NotesApp;Integrated Security=False");
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public Registration()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void btnExut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseDown(object sender, RoutedEventArgs e)
        {

        }


        private void btnLogin_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                con.Open();
                string addData = "INSERT INTO [dbo].[Users] VALUES(@txtUsername.Text, @txtPassword.Password)";
                SqlCommand cmd = new SqlCommand(addData, con);

                cmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
                cmd.Parameters.AddWithValue("@UserPassword", txtPassword.Password);
                cmd.ExecuteNonQuery();
                con.Close();
                txtUsername.Text = "";
                txtPassword.Password = "";
                MainWindow m1 = new MainWindow();
                this.Close();
                m1.Show();
            }
            catch 
            {

                
            }
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainwindow.Show();
        }
    }
}
