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

namespace WpfHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            ListBoxItem david = new ListBoxItem();
            james.Content = "James";
            david.Content = "David";
            peopleListBox.Items.Add(james);
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            if (nameTxtBox1.Text.Length > 2)
            {
                foreach (var item in MainGrid.Children)
                {
                    if (item is TextBox)
                    {
                        s = s + ((TextBox)item).Text;
                        s = s + '\n';
                    }
                }
            MessageBox.Show("Здравей, " + s + "! Това е твоята първа програма на Visual Studio 2022!");
            mainLabel.Content = "Hello, " + s;

        }
            else
            {
                MessageBox.Show(nameTxtBox1.Text + " не е валидно име!");
            }
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nBox1.Text.Length > 0 && yBox1.Text.Length>0)
            {
                int n = Int32.Parse(nBox1.Text);
                int y = Int32.Parse(yBox1.Text);
                int result1 = 1;
                int result2=1;
                
                for (int i = 1; i <= n; i++)
                    result1 = result1 * i;
                for (int i = 0; i < y; i++)
                    result2 *= n;
                resultBox1.Content= n + "!="+ result1 + "\n" + n + "^" + y +"="+result2;
            }
        }

        private void bigButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is Windows Presentation Foundation!");
            mainLabel.Content = DateTime.Now.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            //MessageBox.Show("Hi " + greetingMsg);
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
        }
    }
}
