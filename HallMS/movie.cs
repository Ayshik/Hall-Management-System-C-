using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallMS
{
   public class movie
    {

        DataAccess da = new DataAccess();
        public string showname { get; set; }
        public string type { get; set; }

        public string price { get; set; }
        public string date { get; set; }
        public int sl { get; set; }
        public string text { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string slot { get; set; }
        public string position { get; set; }





    }
}
