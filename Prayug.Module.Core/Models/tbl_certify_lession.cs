using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.Models
{
    public class tbl_certify_lession
    {
        public int lession_id { get; set; }
        public string lession_name { get; set; }
        public string video_path { get; set; }
        public string doc_path { get; set; }
        public int course_id { get; set; }
        public string unit_id { get; set; }
        public string description { get; set; }
        public int user_id { get; set; }
    }
}
