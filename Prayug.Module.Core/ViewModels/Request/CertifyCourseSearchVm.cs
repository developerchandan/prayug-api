using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.ViewModels.Request
{
    public class CertifyCourseSearchVm
    {
        public string course_code { get; set; }
        public string course_name { get; set; }
        public int user_id { get; set; }
    }
}
