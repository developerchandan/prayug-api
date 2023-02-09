using Prayug.Infrastructure.Models;
using Prayug.Module.Core.ViewModels.Request;
using Prayug.Module.Core.ViewModels.Response;
using Prayug.Module.Core.ViewModels.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.Interfaces.RepositoryInterfaces.Web
{
    public interface ILessionRepository
    {
        Task<int> CreateLession(LessionVm entity, TokenInfo token);
        Task<int> CreateCertifyLession(CertifyLessionVm entity, TokenInfo token);
        Task<LessionVm> GetLessionDetail(int subject_id, string unit_id);
        Task<IEnumerable<LessionVm>> getLessionBySubject(int subject_id, string unit_id);
        Task<IEnumerable<LessionVm>> GetCertifyLessionBySubject(int subject_id, string unit_id);
        Task<int> CreateLessionItem(LessionItemVm entity, TokenInfo token);
        Task<int> CreateLessionVideoItem(LessionVideoVm entity, TokenInfo token);
        Task<(IEnumerable<LessionItemListVm>, Int64)> GetLessionItemList(int pageNo, int pageSize, string sortName, string sortType, ItemSearchRequestVm entity);
        Task<(IEnumerable<LessionItemListVm>, Int64)> GetVideoItemList(int pageNo, int pageSize, string sortName, string sortType, ItemSearchRequestVm entity);
        Task<LessionItemListVm> GetItemDetail(int item_id);
        Task<int> SaveQuestions(McqQuestionVm[] entity, int lession_id, TokenInfo userdetail);
        Task<int> SaveMatchQuestions(McqQuestionVm[] entity, int lession_id, TokenInfo userdetail);
        Task<int> SaveWorkbookQuestions(WorkbookQuestionVm[] entity, int lession_id, int course_id, TokenInfo userdetail);
        Task<int> SaveFillInTheBlankQuestions(McqQuestionVm[] entity, int lession_id, TokenInfo userdetail);
        Task<int> GetItemDelete(int item_id);
        Task<(IEnumerable<McqQuestionListVm>, Int64)> GetLessionMcqList(int pageNo, int pageSize, string sortName, string sortType, LessionSearchRequestVm entity);
        Task<(IEnumerable<McqQuestionListVm>, Int64)> GetLessionMatchList(int pageNo, int pageSize, string sortName, string sortType, LessionSearchRequestVm entity);
        Task<(IEnumerable<LessionListVm>, Int64)> GetLessionList(int pageNo, int pageSize, string sortName, string sortType, LessionSearchRequestVm entity);
        Task<(IEnumerable<LessionListVm>, Int64)> GetCertifyLessionList(int pageNo, int pageSize, string sortName, string sortType, CertifyLessionSearchVm entity);
        Task<(IEnumerable<LessionListVm>, Int64)> GetWorkbookList(int pageNo, int pageSize, string sortName, string sortType, LessionSearchRequestVm entity);
        Task<(IEnumerable<LessionListVm>, Int64)> GetFillInTheBlankList(int pageNo, int pageSize, string sortName, string sortType, LessionSearchRequestVm entity);
        Task<int> DeleteLession(int lessiont_id);
        Task<CourseVideoVm> GetCertifyVideoByCourse(int subject_id);
    }
}
