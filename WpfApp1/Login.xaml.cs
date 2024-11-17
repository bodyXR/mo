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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        folderEntities db=new folderEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = db.usertables.FirstOrDefault(x => x.Email == email.Text && x.password == pass.Text);
            if (user != null)
            {
                if (user.role == "Manager")
                {
                    Admin admin = new Admin();
                    this.NavigationService.Navigate(admin);
                }
                else
                {
                    MessageBox.Show("Login secssful");
                    Employess employess = new Employess(user.userID);
                    this.NavigationService.Navigate(employess);
                }
            }
          
        }
    }
}
