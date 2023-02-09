using Dapper;
using Prayug.Module.Core.Interfaces;
using Prayug.Module.Core.Models;
using Prayug.Module.DataBaseHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.Concrete
{
    public class LessionConcrete : ILession
    {
        public async Task<tbl_unit_lession> CheckLessionExist(IDbConnection conn, string lession_name, int subject_id, string unit_id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_lession_name", lession_name);
            param.Add("p_subject_id", subject_id);
            param.Add("p_unit_id", unit_id);
            return await conn.QueryFirstOrDefaultAsync<tbl_unit_lession>(@"usp_core_check_lession_exist", param, commandType: CommandType.StoredProcedure);
        }
        public async Task<tbl_certify_lession> CheckCertifyLessionExist(IDbConnection conn, string lession_name, int course_id, string unit_id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_lession_name", lession_name);
            param.Add("p_course_id", course_id);
            param.Add("p_unit_id", unit_id);
            return await conn.QueryFirstOrDefaultAsync<tbl_certify_lession>(@"usp_core_check_certify_lession_exist", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreateLession(IDbConnection conn, IDbTransaction tran, string lession_name, int subject_id, string unit_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_lession_name", lession_name);
                param.Add("p_subject_id", subject_id);
                param.Add("p_unit_id", unit_id);
                return await conn.ExecuteAsync("usp_core_create_lession", param, tran, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public async Task<int> CreateCertifyLession(IDbConnection conn, IDbTransaction tran, string lession_name, int course_id, string unit_id, int user_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_lession_name", lession_name);
                param.Add("p_course_id", course_id);
                param.Add("p_unit_id", unit_id);
                param.Add("p_user_id", user_id);
                return await conn.ExecuteAsync("usp_core_create_certify_lession", param, tran, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }


        public async Task<int> CreateLessionItem(IDbConnection conn, IDbTransaction tran, int lession_id, int subject_id, string unit_id, string item_name, string language_name, string item_path)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_lession_id", lession_id);
                param.Add("p_subject_id", subject_id);
                param.Add("p_unit_id", unit_id);
                param.Add("p_item_name", item_name);
                param.Add("p_language_name", language_name);
                param.Add("p_item_path", item_path);
                return await conn.ExecuteAsync("usp_core_create_lession_item", param, tran, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public async Task<int> CreateLessionVideoItem(IDbConnection conn, IDbTransaction tran, int lession_id, int course_id, string unit_id, string item_name, string language_name, string item_path)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_lession_id", lession_id);
                param.Add("p_course_id", course_id);
                param.Add("p_unit_id", unit_id);
                param.Add("p_item_name", item_name);
                param.Add("p_language_name", language_name);
                param.Add("p_item_path", item_path);
                return await conn.ExecuteAsync("usp_core_create_lession_video_item", param, tran, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<tbl_unit_lession>> getLessionBySubject(IDbConnection conn, int subject_id, string unit_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_subject_id", subject_id);
                param.Add("p_unit_id", unit_id);
                return await conn.QueryAsync<tbl_unit_lession>(@"usp_core_get_lession_list_by_subject", param, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<tbl_unit_lession>> GetCertifyLessionBySubject(IDbConnection conn, int subject_id, string unit_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_subject_id", subject_id);
                param.Add("p_unit_id", unit_id);
                return await conn.QueryAsync<tbl_unit_lession>(@"usp_core_get_certify_lession_list_by_subject", param, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public async Task<(IEnumerable<lession_item_list>, long)> GetLessionItemList(IDbConnection conn, QueryParameters query)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_sort_expression", query.sort_expression);
            param.Add("p_page_size", query.page_size);
            param.Add("p_offsetCount", query.offsetCount);
            param.Add("p_search_query", query.search_query);

            var multi = await conn.QueryMultipleAsync(@"usp_core_get_item_list", param, null, commandType: CommandType.StoredProcedure);

            return (await multi.ReadAsync<lession_item_list>(), await multi.ReadSingleAsync<Int64>());
        }
        public async Task<(IEnumerable<lession_item_list>, long)> GetVideoItemList(IDbConnection conn, QueryParameters query)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_sort_expression", query.sort_expression);
            param.Add("p_page_size", query.page_size);
            param.Add("p_offsetCount", query.offsetCount);
            param.Add("p_search_query", query.search_query);

            var multi = await conn.QueryMultipleAsync(@"usp_core_get_video_item_list", param, null, commandType: CommandType.StoredProcedure);

            return (await multi.ReadAsync<lession_item_list>(), await multi.ReadSingleAsync<Int64>());
        }

        public async Task<tbl_lession_item> GetItemDetail(IDbConnection conn, int item_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_item_id", item_id);
                return await conn.QueryFirstOrDefaultAsync<tbl_lession_item>(@"usp_core_get_item_detail_byid", param, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public async Task<int> SaveQuestions(IDbConnection conn, IDbTransaction tran, mcq_question question)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_lession_id", question.lession_id);
            param.Add("p_question_id", question.question_id);
            param.Add("p_question", question.question);
            param.Add("p_sequence", question.sequence);
            param.Add("p_type_of_question", question.type_of_question);
            //return await conn.ExecuteAsync(@"usp_support_assessment_question_save", param, tran, commandType: CommandType.StoredProcedure);
            return await conn.QueryFirstOrDefaultAsync<int>(@"usp_mcq_question_save", param, tran, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> SaveAnswers(IDbConnection conn, IDbTransaction tran, string json)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("p_json", json);
            return await conn.ExecuteAsync(@"usp_mcq_answer_save", param, tran, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> SaveLessionMcq(IDbConnection conn, IDbTransaction tran, int lession_id)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("p_lession_id", lession_id);
            return await conn.QueryFirstOrDefaultAsync<int>(@"usp_mcq_item_save_by_lession", param, tran, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> SaveMatchQuestions(IDbConnection conn, IDbTransaction tran, mcq_question question)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_lession_id", question.lession_id);
            param.Add("p_question_id", question.question_id);
            param.Add("p_question", question.question);
            param.Add("p_sequence", question.sequence);
            param.Add("p_type_of_question", question.type_of_question);
            //return await conn.ExecuteAsync(@"usp_support_assessment_question_save", param, tran, commandType: CommandType.StoredProcedure);
            return await conn.QueryFirstOrDefaultAsync<int>(@"usp_match_question_save", param, tran, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> SaveMatchAnswers(IDbConnection conn, IDbTransaction tran, string json)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("p_json", json);
            return await conn.ExecuteAsync(@"usp_match_answer_save", param, tran, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> SaveLessionMatch(IDbConnection conn, IDbTransaction tran, int lession_id)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("p_lession_id", lession_id);
            return await conn.QueryFirstOrDefaultAsync<int>(@"usp_match_item_save_by_lession", param, tran, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> SaveWorkbookQuestions(IDbConnection conn, IDbTransaction tran, workbook_question question)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_lession_id", question.lession_id);
            param.Add("p_course_id", question.course_id);
            param.Add("p_question_id", question.question_id);
            param.Add("p_question", question.question);
            param.Add("p_sequence", question.sequence);
            return await conn.QueryFirstOrDefaultAsync<int>(@"usp_workbook_question_save", param, tran, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> SaveLessionWorkbook(IDbConnection conn, IDbTransaction tran, int lession_id)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("p_lession_id", lession_id);
            return await conn.QueryFirstOrDefaultAsync<int>(@"usp_workbook_item_save_by_lession", param, tran, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> SaveFillInTheBlankQuestions(IDbConnection conn, IDbTransaction tran, mcq_question question)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_lession_id", question.lession_id);
            //param.Add("p_course_id", question.course_id);
            param.Add("p_question_id", question.question_id);
            param.Add("p_question", question.question);
            param.Add("p_sequence", question.sequence);
            return await conn.QueryFirstOrDefaultAsync<int>(@"usp_fill_in_the_blank_question_save", param, tran, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> SaveFillInTheBlankAnswers(IDbConnection conn, IDbTransaction tran, string json)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("p_json", json);
            return await conn.ExecuteAsync(@"usp_fblank_answer_save", param, tran, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> SaveLessionFillInTheBlank(IDbConnection conn, IDbTransaction tran, int lession_id)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("p_lession_id", lession_id);
            return await conn.QueryFirstOrDefaultAsync<int>(@"usp_fill_in_the_blank_item_save_by_lession", param, tran, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> GetItemDelete(IDbConnection conn, IDbTransaction tran, int item_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_item_id", item_id);
                return await conn.ExecuteAsync(@"usp_core_delete_lession_item", param, tran, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public async Task<(IEnumerable<mcq_item_list>, long)> GetLessionMcqList(IDbConnection conn, QueryParameters query)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_sort_expression", query.sort_expression);
            param.Add("p_page_size", query.page_size);
            param.Add("p_offsetCount", query.offsetCount);
            param.Add("p_search_query", query.search_query);

            var multi = await conn.QueryMultipleAsync(@"usp_core_get_mcq_item_list", param, null, commandType: CommandType.StoredProcedure);

            return (await multi.ReadAsync<mcq_item_list>(), await multi.ReadSingleAsync<Int64>());
        }
        public async Task<(IEnumerable<mcq_item_list>, long)> GetLessionMatchList(IDbConnection conn, QueryParameters query)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_sort_expression", query.sort_expression);
            param.Add("p_page_size", query.page_size);
            param.Add("p_offsetCount", query.offsetCount);
            param.Add("p_search_query", query.search_query);

            var multi = await conn.QueryMultipleAsync(@"usp_core_get_match_item_list", param, null, commandType: CommandType.StoredProcedure);

            return (await multi.ReadAsync<mcq_item_list>(), await multi.ReadSingleAsync<Int64>());
        }
        public async Task<(IEnumerable<lession_list>, long)> GetLessionList(IDbConnection conn, QueryParameters query)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_sort_expression", query.sort_expression);
            param.Add("p_page_size", query.page_size);
            param.Add("p_offsetCount", query.offsetCount);
            param.Add("p_search_query", query.search_query);

            var multi = await conn.QueryMultipleAsync(@"usp_core_get_lession_list", param, null, commandType: CommandType.StoredProcedure);

            return (await multi.ReadAsync<lession_list>(), await multi.ReadSingleAsync<Int64>());
        }
        public async Task<(IEnumerable<lession_list>, long)> GetCertifyLessionList(IDbConnection conn, QueryParameters query)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_sort_expression", query.sort_expression);
            param.Add("p_page_size", query.page_size);
            param.Add("p_offsetCount", query.offsetCount);
            param.Add("p_search_query", query.search_query);

            var multi = await conn.QueryMultipleAsync(@"usp_core_get_certify_lession_list", param, null, commandType: CommandType.StoredProcedure);

            return (await multi.ReadAsync<lession_list>(), await multi.ReadSingleAsync<Int64>());
        }

        public async Task<(IEnumerable<lession_list>, long)> GetWorkbookList(IDbConnection conn, QueryParameters query)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_sort_expression", query.sort_expression);
            param.Add("p_page_size", query.page_size);
            param.Add("p_offsetCount", query.offsetCount);
            param.Add("p_search_query", query.search_query);

            var multi = await conn.QueryMultipleAsync(@"usp_core_get_workbook_list", param, null, commandType: CommandType.StoredProcedure);

            return (await multi.ReadAsync<lession_list>(), await multi.ReadSingleAsync<Int64>());
        }
        public async Task<(IEnumerable<lession_list>, long)> GetFillInTheBlankList(IDbConnection conn, QueryParameters query)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_sort_expression", query.sort_expression);
            param.Add("p_page_size", query.page_size);
            param.Add("p_offsetCount", query.offsetCount);
            param.Add("p_search_query", query.search_query);

            var multi = await conn.QueryMultipleAsync(@"usp_core_get_fill_in_the_blank_list", param, null, commandType: CommandType.StoredProcedure);

            return (await multi.ReadAsync<lession_list>(), await multi.ReadSingleAsync<Int64>());
        }
        public async Task<int> DeleteLession(IDbConnection conn, IDbTransaction tran, int lession_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_lession_id", lession_id);
                return await conn.ExecuteAsync(@"usp_core_delete_lession_by_lession_id", param, tran, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public async Task<certify_course_list> GetCertifyVideoByCourse(IDbConnection conn, int course_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_course_id", course_id);
                return await conn.QueryFirstOrDefaultAsync<certify_course_list>(@"usp_core_get_certify_course_detail_byid", param, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<tbl_certify_lession>> GetCertifyLessionListByCourse(IDbConnection conn, int course_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_course_id", course_id);
                return await conn.QueryAsync<tbl_certify_lession>(@"usp_core_get_certify_lession_detail_bycourseid", param, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<lession_item_list>> GetVideoListByCourse(IDbConnection conn, int course_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_course_id", course_id);
                return await conn.QueryAsync<lession_item_list>(@"usp_core_get_certify_course_list_by_courseid", param, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
    }
}
