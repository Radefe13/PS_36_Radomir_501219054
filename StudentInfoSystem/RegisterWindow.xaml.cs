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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = userbox.Text.ToString();
            string pass = passbox.Password.ToString();
            foreach (Student st in StudentData.TestStudents)
            {
                if (user == st.Username && pass == st.Password)
                {
                    MainWindow mw = new MainWindow(st);
                    mw.Show();
                    this.Close();
                }
            }
        }
    }
}
