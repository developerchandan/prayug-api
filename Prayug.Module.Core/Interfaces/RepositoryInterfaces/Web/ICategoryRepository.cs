using Prayug.Infrastructure.Models;
using Prayug.Module.Core.ViewModels.Request;
using Prayug.Module.Core.ViewModels.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.Interfaces.RepositoryInterfaces.Web
{
    public interface ICategoryRepository
    {
        Task<int> CreateCategory(CategoryVm entity, TokenInfo token); 
        Task<int> CreateCertifyCategory(CertifyCategoryVm entity, TokenInfo token); 
        Task<IEnumerable<CategoryVm>> GetCategoryList();
        Task<IEnumerable<CertifyCategoryVm>> GetCertifyCategoryList(int user_id);
        Task<(IEnumerable<CertifyCategoryVm>, Int64)> GetCertifyCategoryList(int pageNo, int pageSize, string sortName, string sortType, CertifyCategorySearchRequestVm entity);
        Task<IEnumerable<CategoryCourses>> GetCategoryCourses();
        Task<IEnumerable<CategoryCourses>> GetCertifyCategoryCourses();
        Task<IEnumerable<CategoryCourses>> GetUserTextSearch(string user_search);
    }
}
