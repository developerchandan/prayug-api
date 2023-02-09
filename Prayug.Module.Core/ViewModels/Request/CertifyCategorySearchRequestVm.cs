using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.ViewModels.Request
{
    public class CertifyCategorySearchRequestVm
    {
        public string category_code { get; set; }
        public string category_name { get; set; }
        public int user_id { get; set; }
    }
}
