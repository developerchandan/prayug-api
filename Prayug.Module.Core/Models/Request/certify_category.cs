using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.Models.Request
{
    public class certify_category
    {
        public int category_id { get; set; }
        public string category_code { get; set; }
        public string category_name { get; set; }
        public int user_id { get; set; }
    }
}
