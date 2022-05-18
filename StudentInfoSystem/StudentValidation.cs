using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            StudentInfoContext context = new StudentInfoContext();
            Student result =
(from st in context.Students
 where st.FacultyNum == user.Fac_no
 select st).First();
            return result;

        }
    }
}
