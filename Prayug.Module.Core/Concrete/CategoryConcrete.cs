using Dapper;
using Google.Protobuf.WellKnownTypes;
using Prayug.Module.Core.Interfaces;
using Prayug.Module.Core.Models;
using Prayug.Module.Core.Models.Request;
using Prayug.Module.DataBaseHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayug.Module.Core.Concrete
{
    public class CategoryConcrete : ICategory
    {
        public async Task<tbl_category_vm> CheckCategoryExist(IDbConnection conn, string category_code, string category_name)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_category_code", category_code);
            param.Add("p_category_name", category_name);

            return await conn.QueryFirstOrDefaultAsync<tbl_category_vm>(@"usp_core_check_category_exist", param, commandType: CommandType.StoredProcedure);
        }
        public async Task<certify_category> CheckCertifyCategoryExist(IDbConnection conn, string category_code, string category_name)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_category_code", category_code);
            param.Add("p_category_name", category_name);

            return await conn.QueryFirstOrDefaultAsync<certify_category>(@"usp_core_check_certify_category_exist", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreateCategory(IDbConnection conn, IDbTransaction tran, string category_code, string category_name, int course_type, string duration)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_category_code", category_code);
                param.Add("p_category_name", category_name);
                param.Add("p_course_type", course_type);
                param.Add("p_duration", duration);
                return await conn.ExecuteAsync("usp_core_create_category", param, tran, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public async Task<int> CreateCertifyCategory(IDbConnection conn, IDbTransaction tran, string category_code, string category_name, int user_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_category_code", category_code);
                param.Add("p_category_name", category_name);
                param.Add("p_user_id", user_id);
                return await conn.ExecuteAsync("usp_core_create_certify_category", param, tran, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<tbl_category_vm>> GetCategoryList(IDbConnection conn)
        {
            try
            {
                //DynamicParameters param = new DynamicParameters();

                return await conn.QueryAsync<tbl_category_vm>(@"usp_core_get_category_all_list", null, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<certify_category>> GetCertifyCategoryList(IDbConnection conn, int user_id)
        {
            try
            {
                //DynamicParameters param = new DynamicParameters();
                DynamicParameters param = new DynamicParameters();
                param.Add("p_user_id", user_id);
                return await conn.QueryAsync<certify_category>(@"usp_core_get_certify_category_by_user", param, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public async Task<(IEnumerable<certify_category>, long)> GetCertifyCategoryList(IDbConnection conn, QueryParameters query)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_sort_expression", query.sort_expression);
            param.Add("p_page_size", query.page_size);
            param.Add("p_offsetCount", query.offsetCount);
            param.Add("p_search_query", query.search_query);

            var multi = await conn.QueryMultipleAsync(@"usp_core_get_certify_category_all_list", param, null, commandType: CommandType.StoredProcedure);

            return (await multi.ReadAsync<certify_category>(), await multi.ReadSingleAsync<Int64>());
        }
        public async Task<IEnumerable<category_courses>> GetCategoryCourses(IDbConnection conn)
        {
            try
            {
                //DynamicParameters param = new DynamicParameters();

                return await conn.QueryAsync<category_courses>(@"usp_core_get_category_course_count", null, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<category_courses>> GetUserTextSearch(IDbConnection conn, string user_search)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_user_search", user_search);
                return await conn.QueryAsync<category_courses>(@"usp_core_get_user_search_category_course", param, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
    }
}
