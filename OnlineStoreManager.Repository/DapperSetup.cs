using DapperExtensions.Mapper;
using System.Reflection;

namespace OnlineStoreManager.Repository
{
    public class DapperSetup
    {
        /// <summary>
        /// Method to set default Dapper settings
        /// </summary>
        public static void SetUpDapperExtensions()
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(PluralizedAutoClassMapper<>);

            // Tell Dapper Extension to scan this assembly for custom mappings
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[]
            {
                Assembly.Load("OnlineStoreManager.Repository")
            });
        }
    }
}

