using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        folderEntities db =new folderEntities();
        public Admin()
        {
            InitializeComponent();
            grid.ItemsSource=db.Tasks.Select(s => new { s.TaskId, s.title, s.Descrption, s.status }).ToList();
       
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Task task = new Task();

            int id = int.Parse(uipo.Text);
            var ema=db.Tasks.FirstOrDefault(x=>x.TaskId == id);
            if (ema != null)
            {
                db.Tasks.Remove(ema);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("eror");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Task task = new Task();
            int id = int.Parse(uipo.Text);
            var ema = db.Tasks.FirstOrDefault(x => x.TaskId == id);
            if (ema == null)
            {
                var email = db.usertables.FirstOrDefault(x => x.Email == name.Text);
                if (email != null)
                {
                    task.title = title.Text;
                    task.Descrption = Desk.Text;
                    task.status = n.Text;
                    ema.userID = email.userID;
                    db.Tasks.Add(task);
                    db.SaveChanges();

                }
                



            }


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Task task = new Task();
            int id = int.Parse(uipo.Text);
            var ema = db.Tasks.FirstOrDefault(x => x.TaskId == id);
            if (ema != null)
            {
                var email = db.usertables.FirstOrDefault(x => x.Email == name.Text);
                if (email != null)
                {
                    task.TaskId = id;
                    task.title = title.Text;
                    task.Descrption = Desk.Text;
                    task.status = n.Text;
                    ema.TaskId = email.userID;
                    db.Tasks.AddOrUpdate(task);
                    db.SaveChanges();

                }




            }
        }
    }
}
