﻿using Dapper;
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
    public class UnitConcrete : IUnit
    {
        public async Task<tbl_subject_curriculum> CheckUnitExist(IDbConnection conn, int course_id, int subject_id, string unit_id)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("p_course_id", course_id);
            param.Add("p_subject_id", subject_id);
            param.Add("p_unit_id", unit_id);
            return await conn.QueryFirstOrDefaultAsync<tbl_subject_curriculum>(@"usp_core_check_unit_exist", param, commandType: CommandType.StoredProcedure);
        }
        public async Task<certify_unit> CheckCertifyUnitExist(IDbConnection conn, int course_id, string unit_id)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("p_course_id", course_id);
            param.Add("p_unit_id", unit_id);
            return await conn.QueryFirstOrDefaultAsync<certify_unit>(@"usp_core_check_certify_unit_exist", param, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> CreateUnit(IDbConnection conn, IDbTransaction tran, int course_id, int subject_id, string unit_id, int sequensce)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_course_id", course_id);
                param.Add("p_subject_id", subject_id);
                param.Add("p_unit_id", unit_id);
                param.Add("p_sequensce", sequensce);
                return await conn.ExecuteAsync("usp_core_create_unit", param, tran, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }
        public async Task<int> CreateCertifyUnit(IDbConnection conn, IDbTransaction tran, int course_id, string unit_id, int user_id, int sequensce)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_course_id", course_id);
                param.Add("p_unit_id", unit_id);
                param.Add("p_user_id", user_id);
                param.Add("p_sequensce", sequensce);
                return await conn.ExecuteAsync("usp_core_create_certify_unit", param, tran, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public async Task<tbl_course_vm> GetUnitDetail(IDbConnection conn, int subject_id, string unit_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_subject_id", subject_id);
                param.Add("p_unit_id", unit_id);
                return await conn.QueryFirstOrDefaultAsync<tbl_course_vm>(@"usp_core_get_unit_detail_by_unitid", param, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public async Task<(IEnumerable<unit_list>, long)> GetUnitList(IDbConnection conn, QueryParameters query)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_sort_expression", query.sort_expression);
            param.Add("p_page_size", query.page_size);
            param.Add("p_offsetCount", query.offsetCount);
            param.Add("p_search_query", query.search_query);

            var multi = await conn.QueryMultipleAsync(@"usp_core_get_unit_list", param, null, commandType: CommandType.StoredProcedure);

            return (await multi.ReadAsync<unit_list>(), await multi.ReadSingleAsync<Int64>());
        }

        public async Task<(IEnumerable<certify_unit>, long)> GetCertifyUnitList(IDbConnection conn, QueryParameters query)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("p_sort_expression", query.sort_expression);
            param.Add("p_page_size", query.page_size);
            param.Add("p_offsetCount", query.offsetCount);
            param.Add("p_search_query", query.search_query);

            var multi = await conn.QueryMultipleAsync(@"usp_core_get_certify_unit_list", param, null, commandType: CommandType.StoredProcedure);

            return (await multi.ReadAsync<certify_unit>(), await multi.ReadSingleAsync<Int64>());
        }
        public async Task<int> DeleteUnit(IDbConnection conn, IDbTransaction tran, int subject_id, string unit_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_subject_id", subject_id);
                param.Add("p_unit_id", unit_id);
                return await conn.ExecuteAsync(@"usp_core_delete_unit_by_subject_id", param, tran, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

    }
}
