using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace PR3_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public int answers(params RadioButton[] answ)
        {
            int count = 0;
            foreach (RadioButton but in answ)
            {
                if (but.IsChecked == true) count++;
            }
            return count;
        }
        public class PersonContext : DbContext
        {
            public PersonContext() : base("Database1Entities")
            {

            }
            public DbSet<Logins> Users { get; set; }
        }

        private void loginB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PersonContext context = new PersonContext();
                if (context.Users.Any(o => o.Login == loginText.Text && o.Password == passwordText.Password))
                {
                    Test t = new Test();
                    t.Show();
                }
                else
                {
                    MessageBox.Show("Логин или пароль не подходит");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
