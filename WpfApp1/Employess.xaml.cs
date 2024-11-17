using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class Employess : Page
    {
        // Assuming 'folderEntities' is your Entity Framework context
        folderEntities db = new folderEntities();
        int ido;

        public Employess(int id)
        {
            this.ido = id;
            InitializeComponent();

         
            var pendingTasks = db.Tasks.Where(t => t.status == "pending" || t.status == "in proggres")
                                       .Select(s => new { s.TaskId, s.title, s.Descrption, s.status })
                                       .ToList();
            db1.ItemsSource = pendingTasks;

            var completedTasks = db.Tasks.Where(t => t.status == "completed")
                                         .Select(s => new { s.TaskId, s.title, s.Descrption, s.status })
                                         .ToList();
            db2.ItemsSource = completedTasks;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        int id = int.Parse(nio.Text);


                string selectedStatus = mon.SelectedValue.ToString();

            
              
                var taskToUpdate = db.Tasks.FirstOrDefault(t => t.TaskId == id);
                if (taskToUpdate != null)
                {
                    taskToUpdate.status = selectedStatus;
                    db.Tasks.AddOrUpdate(taskToUpdate);
                    db.SaveChanges();  

                    var pendingTasks = db.Tasks.Where(t => t.status == "pending" || t.status == "in Progress")
                                                .Select(s => new { s.TaskId, s.title, s.Descrption, s.status })
                                                .ToList();
                    db1.ItemsSource = pendingTasks;
                    var completedTasks = db.Tasks.Where(t => t.status == "completed")
                                                    .Select(s => new { s.TaskId, s.title, s.Descrption, s.status})
                                                    .ToList();
                    db2.ItemsSource = completedTasks;
                }
                else
                {
                    MessageBox.Show("Task not found.", "Error");
                }
            

        }
    }
}