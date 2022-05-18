using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        private string username;        
        private string password;
        private string name;
        private string secondName;
        private string lastName;
        private string faculty;
        private string field;
        private string qualification;
        private string status;
        private string facultyNum;
        private int year;
        private int stream;
        private int group;

        public int StudentId { get; set; }
        public string Username { get =>username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Faculty { get => faculty; set => faculty = value; }
        public string Field { get => field; set => field = value; }
        public string Qualification { get => qualification; set => qualification = value; }
        public string Status { get => status; set => status = value; }
        public string FacultyNum { get => facultyNum; set => facultyNum = value; }
        public int Year { get => year; set => year = value; }
        public int Stream { get => stream; set => stream = value; }
        public int Group { get => group; set => group = value; }

        public Student() { }
        
        public Student(string name, string secondName, 
            string lastName, string faculty, string field,
            string qualification, string status, string facultyNum,
            int year, int stream, int group)
        {
            this.Name = name;
            this.SecondName = secondName;
            this.LastName = lastName;
            this.Faculty = faculty;
            this.Field = field;
            this.Qualification = qualification;
            this.Status = status;
            this.FacultyNum = facultyNum;
            this.Year = year;
            this.Stream = stream;
            this.Group = group;
        }


    }
}
