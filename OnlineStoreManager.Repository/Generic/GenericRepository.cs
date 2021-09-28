using Dapper;
using OnlineStoreManager.Domain;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineStoreManager.Repository.Generic
{
    public class GenericRepository<TEntity> where TEntity : BaseEntity
    {
        private string _connectionString;

        public GenericRepository(string connectionStringName)
        {
            _connectionString = GetConnectionString(connectionStringName);
        }

        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<TEntity> GetAll<TParam>(string storedProcedure, TParam parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var data = connection.Query<TEntity>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }

        public TEntity Get(string storedProcedure, dynamic id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var data = connection.QuerySingle<TEntity>(storedProcedure, new { Id = id }, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public void Add(string storedProcedure, TEntity parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}