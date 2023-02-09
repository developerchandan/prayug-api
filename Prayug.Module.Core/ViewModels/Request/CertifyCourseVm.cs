using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.ViewModels.Request
{
    public class CertifyCourseVm
    {
        public int user_id { get; set; }
        public int course_id { get; set; }
        public string course_code { get; set; }
        public string course_name { get; set; }
        public string category { get; set; }
        public string image_path { get; set; }
        public string description { get; set; }
        public string sub_description { get; set; }
        public string language_type { get; set; }
    }
}
