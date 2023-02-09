using Prayug.Module.Core.Models;
using Prayug.Module.Core.Models.Request;
using Prayug.Module.DataBaseHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.Interfaces
{
    public interface ICategory
    {
        Task<tbl_category_vm> CheckCategoryExist(IDbConnection conn, string category_code, string category_name);
        Task<certify_category> CheckCertifyCategoryExist(IDbConnection conn, string category_code, string category_name);
        Task<int> CreateCategory(IDbConnection conn, IDbTransaction tran, string category_code, string category_name, int course_type, string duration);
        Task<int> CreateCertifyCategory(IDbConnection conn, IDbTransaction tran, string category_code, string category_name, int user_id);
        Task<IEnumerable<tbl_category_vm>> GetCategoryList(IDbConnection conn);
        Task<IEnumerable<certify_category>> GetCertifyCategoryList(IDbConnection conn, int user_id);
        Task<(IEnumerable<certify_category>, long)> GetCertifyCategoryList(IDbConnection conn, QueryParameters query);
        Task<IEnumerable<category_courses>> GetCategoryCourses(IDbConnection conn);
        Task<IEnumerable<category_courses>> GetUserTextSearch(IDbConnection conn, string user_search);
    }
}
