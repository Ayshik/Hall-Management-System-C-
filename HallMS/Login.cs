using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallMS
{
   public class Login
    {
        DataAccess da = new DataAccess();
        public string Password { get; set; }
        public string Userid { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string ques { get; set; }
        public string ans { get; set; }

    }
}
