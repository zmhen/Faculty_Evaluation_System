using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty_Evaluation_System
{
    class InfoSetting
    {

        public int faculty_id { get; set; }
        public string role { get; set; }
        public string token { get; set; }

        public int users_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birthdate { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public int scale1 { get; set; }
        public int scale2 { get; set; }
        public int scale3 { get; set; }
        public int scale4 { get; set; }
        public int scale5 { get; set; }


    }
}
