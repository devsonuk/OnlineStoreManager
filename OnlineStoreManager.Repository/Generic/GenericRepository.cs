using Dapper;
using DapperExtensions;
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
        public string ConnectionString { get; set; }
        private IList<ISort> PageSort { get; set; }
        private int PageOffset { get; set; }
        private int PageLimit { get; set; }

        public GenericRepository(string connectionStringName)
        {
            PageSort = new List<ISort>
            {
                Predicates.Sort<TEntity>(entity => entity.Id)
            };
            PageOffset = 0;
            PageLimit = 1000;
            ConnectionString = GetConnectionString(connectionStringName);
        }

        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        #region Add Methods

        /// <inheritdoc cref="Add"/>
        public int Add(TEntity entity)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Insert(entity);
            }
        }

        #endregion Add Methods

        #region Delete methods

        /// <inheritdoc/>
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var entity = connection.Get<TEntity>(id);
                connection.Delete(entity);
            }
        }

        #endregion Delete methods

        #region Update methods

        /// <inheritdoc cref="IGenericRepository{TEntity}.Update"/>
        public bool Update(TEntity entity)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Update(entity);
            }
        }

        #endregion Update methods

        #region Get methods

        /// <inheritdoc cref="IGenericRepository{TEntity}.SetPageOffset(int)"/>
        public void SetPageOffset(int pageOffset)
        {
            PageOffset = pageOffset;
        }

        /// <inheritdoc cref="IGenericRepository{TEntity}.SetPageLimit(int)"/>
        public void SetPageLimit(int pageLimit)
        {
            PageLimit = pageLimit;
        }

        /// <inheritdoc cref="IGenericRepository{TEntity}.SetPageSort(IList{ISort})"/>
        public void SetPageSort(IList<ISort> sortData)
        {
            PageSort = sortData;
        }

        /// <inheritdoc cref="IGenericRepository{TEntity}.SetPageSort(IList{ISort})"/>
        public void SetPagingParameters(int pageOffset, int pageLimit, IList<ISort> sortData)
        {
            PageOffset = pageOffset;
            PageLimit = pageLimit;
            PageSort = sortData;
        }

        /// <inheritdoc cref="IGenericRepository{TEntity}.SetPagingParameters(int,int)"/>
        public void SetPagingParameters(int pageOffset, int pageLimit)
        {
            PageOffset = pageOffset;
            PageLimit = pageLimit;
        }

        /// <inheritdoc cref="IGenericRepository{TEntity}.Get(int)"/>
        public TEntity Get(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Get<TEntity>(id);
            }
        }

        /// <summary>
        /// Returns the entities matched by entityIds
        /// </summary>
        /// <param name="entityIds">The Ids of the entities</param>
        /// <returns>
        /// Entities
        /// </returns>
        public IEnumerable<TEntity> Get(IEnumerable<int> entityIds)
        {
            var predicateGroup = new PredicateGroup
            {
                Operator = GroupOperator.Or,
                Predicates = entityIds.Select(e => { return Predicates.Field<TEntity>(dp => dp.Id, Operator.Eq, e); }).ToList<IPredicate>()
            };

            return GetByPredicate(predicateGroup);
        }

        /// <inheritdoc cref="IGenericRepository{TEntity}.Get(string)"/>
        public TEntity Get(string id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Get<TEntity>(id);
            }
        }

        /// <inheritdoc cref="IGenericRepository{TEntity}.GetByPredicate(IFieldPredicate)"/>
        public IEnumerable<TEntity> GetByPredicate(IFieldPredicate predicate)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.GetPage<TEntity>(predicate, PageSort, PageOffset, PageLimit).ToList();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<TEntity> GetByPredicate(IPredicateGroup predicateGroup)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.GetPage<TEntity>(predicateGroup, PageSort, PageOffset, PageLimit).ToList();
            }
        }

        /// <inheritdoc cref="IGenericRepository{TEntity}.GetAll"/>
        public IEnumerable<TEntity> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.GetPage<TEntity>(null, PageSort, PageOffset, PageLimit).ToList();
            }
        }

        #endregion Get methods

        #region Count Methods

        /// <inheritdoc cref="IGenericRepository{TEntity}.Count(IFieldPredicate)"/>
        public long Count(IFieldPredicate predicate)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Count<TEntity>(predicate);
            }
        }

        /// <inheritdoc cref="IGenericRepository{TEntity}.CountByPredicateGroup(IPredicateGroup)"/>
        public long CountByPredicateGroup(IPredicateGroup predicateGroup)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Count<TEntity>(predicateGroup);
            }
        }

        #endregion Count Methods

        #region Custome Methods
        public List<T> GetAll<T, U>(string storedProcedure, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public T Get<T, U>(string storedProcedure, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.QuerySingle<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Add<T>(string storedProcedure, T parameters)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        #endregion Custome Methods
    }
}