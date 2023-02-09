﻿using Prayug.Module.Core.ViewModels.Request;
using Prayug.Module.Core.ViewModels.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.Interfaces.RepositoryInterfaces.Web
{
    public interface ILearningRepository
    {
        Task<IEnumerable<CourseVm>> GetAllCourse();
        Task<IEnumerable<CertifyCourseVm>> GetAllCertifyCourse(int user_id);
        Task<IEnumerable<GroupVm>> GetAllGroup(int id);
        Task<IEnumerable<SubjectVm>> GetAllSubject(int id);
        Task<IEnumerable<UserSemesterList>> getUserSemester(int user_id);
        Task<int> SaveUserSemester(UserSemesterRequestVm entity);
        Task<IEnumerable<SubjectOverviewVm>> getSubjectOverview(int subject_id);
        Task<IEnumerable<SubjectCurriculumVm>> getSubjectCurriculum(int subject_id);
        Task<IEnumerable<UnitLessionVm>> getSunjectUnit(string unit_name, int subject_id);
        Task<IEnumerable<LessionItemsVm>> getLessionItems(int lession_id);
        Task<CourseVm> GetCourseDetail(int course_id);
        Task<QuizDetailVm> GetQuizByLessionId(int lession_id);
        Task<QuizDetailVm> GetMatchByLessionId(int lession_id);
        Task<LessionItemsVm> GetTopicDetail(int item_id);
        Task<UserVm> GetUserDetail(int user_id);
        Task<UserProfileVm> GetUserProfile(int user_id);
        Task<IEnumerable<CourseVm>> GetAllCourseByCategory(string category_code);
        Task<IEnumerable<CourseVm>> GetAllCourseByCategories(string category_codes);
        Task<WorkbookDetailVm> GetWorkbookByLession(int lession_id);
        Task<int> SaveUserWorkbook(UserWorkbook entity);
        Task<int> CreateUserProfile(UserProfileVm entity);
        Task<int> UpdateUserProfile(ProfileVm entity);
        Task<QuizDetailVm> GetFillInTheBlankByLession(int lession_id);
        Task<int> SaveUserFillInTheBlank(UserWorkbook entity);
    }
}
