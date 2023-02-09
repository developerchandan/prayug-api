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
    public interface ITutor
    {
        Task<(IEnumerable<tbl_course_vm>, Int64)> GetCourseList(IDbConnection conn, QueryParameters query);
        Task<tbl_course_vm> CheckCourseExist(IDbConnection conn, string course_code, string course_name);
        Task<tbl_course_vm> CheckCertifyCourseExist(IDbConnection conn, string course_code, string course_name);
        Task<course_overview> CheckCourseOverviewExist(IDbConnection conn, int course_id);
        Task<int> CreateCourse(IDbConnection conn, IDbTransaction tran, string course_code, string course_name, string image_path, string category, string description);
        Task<int> CreateCertifyCourse(IDbConnection conn, IDbTransaction tran, string course_code, string course_name, string image_path, string category, string description, int user_id, string sub_description, string language_type);
        Task<int> CreateCourseOverview(IDbConnection conn, IDbTransaction tran, int course_id, string image_path, string description);
        Task<int> UpdateCourseOverview(IDbConnection conn, IDbTransaction tran, int course_id, string image_path, string description);
        Task<int> EditCourse(IDbConnection conn, IDbTransaction tran, int course_id, string course_code, string course_name, string image_path, string description);

        Task<int> GetCourseDelete(IDbConnection conn, IDbTransaction tran, int course_id);
        Task<course_structure> CheckCourseStructureExist(IDbConnection conn, int course_id, string item_name);
        Task<int> CreateCourseStructure(IDbConnection conn, IDbTransaction tran, int course_id, string category_code, string item_name, int is_active, string path);
        Task<IEnumerable<course_structure>> GetCourseStructure(IDbConnection conn, int course_id);
        Task<course_skill> CheckCourseSkillExist(IDbConnection conn, int course_id, string skill_name);
        Task<int> CreateCourseSkill(IDbConnection conn, IDbTransaction tran, int course_id, string category_code, string skill_name, string path);
        Task<IEnumerable<course_skill>> GetCourseSkill(IDbConnection conn, int course_id);
        Task<int> CreateOrder(IDbConnection conn, IDbTransaction tran, int user_id, string user_name, string order_number, string course_code, string payment_id);

        Task<(IEnumerable<all_user_list>, Int64)> AllUserList(IDbConnection conn, QueryParameters query);
        Task<int> GetUserActive(IDbConnection conn, IDbTransaction tran, int user_id);
        Task<int> UserPermissionAction(IDbConnection conn, IDbTransaction tran, int user_id);
        Task<int> GetUserDelete(IDbConnection conn, IDbTransaction tran, int user_id);
        Task<all_user_list> GetUserDetail(IDbConnection conn, int user_id);
        Task<course_overview> GetCourseOverview(IDbConnection conn, int course_id);
        Task<(IEnumerable<tbl_course_vm>, Int64)> GetCourseOverviewList(IDbConnection conn, QueryParameters query);
        Task<(IEnumerable<tbl_course_vm>, Int64)> GetCertifyCourseList(IDbConnection conn, QueryParameters query);

    }
}
