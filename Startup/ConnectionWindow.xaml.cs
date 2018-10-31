using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Commutator;
using Contracts.SDO;
namespace Startup
{
    /// <summary>
    /// Логика взаимодействия для ConnectionWindow.xaml
    /// </summary>
    public partial class ConnectionWindow : Window
    {
        public ConnectionWindow()
        {
            InitializeComponent();
        }

        ConnectionSettings conf;

        private void LoadConfig()
        {

          
//var sett=

        }

        private void BuildConfig()
        {
            SqlConnectionStringBuilder sqlbuildExos = new SqlConnectionStringBuilder();
            sqlbuildExos.UserID = exLogin.Text;
            sqlbuildExos.Password = exPassword.Text;
            sqlbuildExos.InitialCatalog = exDatabase.Text;
            sqlbuildExos.DataSource = exServerName.Text;
            conf.ConnctionString = sqlbuildExos.ConnectionString;

            Session.ExosCommutator= new ExosCommutator(conf.ConnctionString);
            //Session.Settings.ConnectionSettings


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BuildConfig();
        }
    }
}
