﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.ViewModels.Web
{
    public class LessionItemListVm
    {
        public int item_id { get; set; }
        public string item_name { get; set; }
        public string item_icon { get; set; }
        public string item_path { get; set; }
        public int lession_id { get; set; }
        public string lession_name { get; set; }
        public string subject_name { get; set; }
        public string language_type { get; set; }
        public string unit_id { get; set; }
        public string course_name { get; set; }
    }
}
