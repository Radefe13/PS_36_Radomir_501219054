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
using System.Data;
using System.Data.SqlClient;


namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            FillStudStatusChoices();
            Student Student = StudentData.TestStudents[0];
            nameBox.Text = Student.Name;
            secondNameBox.Text = Student.SecondName;
            lastNameBox.Text = Student.LastName;
            facultyBox.Text = Student.Faculty;
            fieldBox.Text = Student.Field;
            qualificationBox.Text = Student.Qualification;
            facultyNumBox.Text = Student.FacultyNum;
            yearBox.Text = Student.Year.ToString();
            streamBox.Text = Student.Stream.ToString();
            groupBox.Text = Student.Group.ToString();
            if (TestStudentsIfEmpty())
                CopyTestStudents();

        }
        public MainWindow(Student st)
        {
            InitializeComponent();
            this.DataContext = this;
            FillStudStatusChoices();
            this.Student = st;
            nameBox.Text = Student.Name;
            secondNameBox.Text = Student.SecondName;
            lastNameBox.Text = Student.LastName;
            facultyBox.Text = Student.Faculty;
            fieldBox.Text = Student.Field;
            qualificationBox.Text = Student.Qualification;
            facultyNumBox.Text = Student.FacultyNum;
            yearBox.Text = Student.Year.ToString();
            streamBox.Text = Student.Stream.ToString();
            groupBox.Text = Student.Group.ToString();
            if (TestStudentsIfEmpty())
                CopyTestStudents();

        }
        private Student _student;
        public List<string> StudStatusChoices { get; set; }
        public Student Student { 
            get 
            { 
                return _student;
            }
            set
            {
                if (_student == null)
                {
                    _student = value;
                    clearBoxes();
                    //disableBoxes();
                }
                else
                {
                    enableBoxes();
                    displayStudent(_student);    
                }
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void clearBoxes()
        {
            nameBox.Text = String.Empty;
            secondNameBox.Text = String.Empty;
            lastNameBox.Text = String.Empty;
            facultyBox.Text = String.Empty;
            fieldBox.Text = String.Empty;
            qualificationBox.Text = String.Empty;
            facultyNumBox.Text = String.Empty;
            yearBox.Text = String.Empty;
            streamBox.Text = String.Empty;
            groupBox.Text = String.Empty;
        }
        private void displayStudent(Student student)
        {
        
        }
        private void disableBoxes()
        {
            nameBox.IsEnabled = false;
            secondNameBox.IsEnabled = false;
            lastNameBox.IsEnabled = false;
            facultyBox.IsEnabled = false;
            fieldBox.IsEnabled = false;
            qualificationBox.IsEnabled = false;
            statusBox.IsEnabled = false;
            facultyNumBox.IsEnabled = false;
            yearBox.IsEnabled = false;
            streamBox.IsEnabled = false;
            groupBox.IsEnabled = false;
        }
        private void enableBoxes()
        {
            nameBox.IsEnabled = true;
            secondNameBox.IsEnabled = true;
            lastNameBox.IsEnabled = true;
            facultyBox.IsEnabled = true;
            fieldBox.IsEnabled = true;
            qualificationBox.IsEnabled = true;
            statusBox.IsEnabled = true;
            facultyNumBox.IsEnabled = true;
            yearBox.IsEnabled = true;
            streamBox.IsEnabled = true;
            groupBox.IsEnabled = true;
        }
        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect);
            string sqlquery = @"SELECT StatusDescr FROM StudStatus";
            IDbCommand command = new SqlCommand();
            command.Connection = connection;
            connection.Open();
            command.CommandText = sqlquery;
            IDataReader reader = command.ExecuteReader();
            bool notEndOfResult;
            notEndOfResult = reader.Read();
            while (notEndOfResult)
            {
                string s = reader.GetString(0);
                StudStatusChoices.Add(s);
                notEndOfResult = reader.Read();
            }
        }
        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            return queryStudents.Any()? false : true;
        }
        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isTestStudentsEmpty=TestStudentsIfEmpty();
            MessageBox.Show(isTestStudentsEmpty.ToString(),"Statement");
        }
    }
}
