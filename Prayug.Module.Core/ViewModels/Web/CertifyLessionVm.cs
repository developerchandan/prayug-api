using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.ViewModels.Web
{
    public class CertifyLessionVm
    {
        public int lession_id { get; set; }
        public string lession_name { get; set; }
        public string unit_id { get; set; }
        public int course_id { get; set; }
        public int user_id { get; set; }
        public IEnumerable<LessionItemListVm> item_list { get; set; }
    }
}
