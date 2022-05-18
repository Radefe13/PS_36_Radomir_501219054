using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class User
    {
        public Int32 UserId { get; set; }
        public DateTime Created { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fac_no { get; set; }
        public int Role { get; set; }
        public DateTime ValidUntil { get; set; }


    }
}
