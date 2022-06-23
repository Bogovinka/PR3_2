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
using System.Windows.Shapes;

namespace PR3_2
{
    /// <summary>
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
        }
        private void next_ButtonClick(object sender, RoutedEventArgs e)
        {
            tB.SelectedIndex += 1;
        }

        private void end_ButtonClick(object sender, RoutedEventArgs e)
        {
            End end = new End();
            end.Show();
            end.result.Content = $"Всего правильных ответов: {answers()} из 20\nОценка за тест: {rating(answers())}";
            Close();
        }
        public int answers()
        {
            RadioButton[] answ = { v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20 };
            int count = 0;
            foreach (RadioButton but in answ)
            {
                if (but.IsChecked == true) count++;
            }
            return count;
        }
        public int rating(int count)
        {
            if (count > 16) return 5;
            else if (count > 12 && count <= 16) return 4;
            else if (count >= 8 && count <= 12) return 3;
            else return 2;
        }
    }
}
