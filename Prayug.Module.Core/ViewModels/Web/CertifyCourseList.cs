using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.ViewModels.Web
{
    public class CertifyCourseList
    {
        public int course_id { get; set; }
        public string course_code { get; set; }
        public string course_name { get; set; }
        public int unit_id { get; set; }
        public string unit_name { get; set; }
        public int is_active { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string image_path { get; set; }
        public string category_code { get; set; }
        public string description { get; set; }
    }
}
