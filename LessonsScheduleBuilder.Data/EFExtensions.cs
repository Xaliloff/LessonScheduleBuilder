using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduleBuilder.Data
{
    public static class EFExtensions
    {
        //this two extensions have been created for usage old "SqlQuery" method of EF6 because they were removed in EF Core. Dapper inside.
        public static List<T> SqlQuery<T>(this DatabaseFacade dbFacade, string sql, SqlParameter[] parameters = null)
        {
            DbConnection connection = dbFacade.GetDbConnection();

            DynamicParameters dapperParams = new DynamicParameters(
                parameters == null ?
                new Dictionary<string, object>() :
                parameters.ToDictionary(x => x.ParameterName, x => x?.Value));
            try
            {
                connection.Open();
                List<T> list = connection.Query<T>(sql, dapperParams).ToList();
                connection.Close();
                return list;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }

        public static async Task<List<T>> SqlQueryAsync<T>(this DatabaseFacade dbFacade, string sql, SqlParameter[] parameters = null)
        {
            DbConnection connection = dbFacade.GetDbConnection();

            DynamicParameters dapperParams = new DynamicParameters(
                parameters == null ?
                new Dictionary<string, object>() :
                parameters.ToDictionary(x => x.ParameterName, x => x?.Value));
            try
            {
                await connection.OpenAsync();
                List<T> list = connection.Query<T>(sql, dapperParams).ToList();
                connection.Close();
                return list;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }
    }
}
