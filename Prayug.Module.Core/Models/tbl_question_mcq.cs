﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.Models
{
    public class tbl_question_mcq
    {
        public int question_id { get; set; }
        public string question { get; set; }
        public int question_type { get; set; }
        public int lession_id { get; set; }
        public string unit_id { get; set; }
        public int course_id { get; set; }
    }
}
