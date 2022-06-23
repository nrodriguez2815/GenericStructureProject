using Dapper;
using System.Data;
using UsersAuthWebApi.Data;
using UsersAuthWebApi.Interfaces;

namespace UsersAuthWebApi.Services
{
    public class DataContextService : IDataContextService
    {
        private readonly DapperContext _context;
        public DataContextService(DapperContext context)
        {
            _context = context;
        }
        public async Task<T> ReturnOneAsync<T>(string procedureName, DynamicParameters? param = null)
        {
            try
            {
                using (var sqlConnection = _context.CreateConnection())
                {
                    return await sqlConnection.QueryFirstOrDefaultAsync<T>(procedureName, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                return (T)Convert.ChangeType(ex.Message, typeof(T));
            }
        }
        public async Task<IEnumerable<T>> ReturnListAsync<T>(string procedureName, DynamicParameters? param = null)
        {
            try
            {
                using (var sqlConnection = _context.CreateConnection())
                {
                    return await sqlConnection.QueryAsync<T>(procedureName, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }
        public async Task<string> ExecuteWithReturnAsync(string procedureName, DynamicParameters? param = null)
        {
            try
            {
                using (var sqlConnection = _context.CreateConnection())
                {
                    var result = await sqlConnection.QueryFirstOrDefaultAsync<string>(procedureName, param, commandType: CommandType.StoredProcedure);

                    if (result != null)
                        return result.ToString();
                }

                return "An error has ocurred. The query returned a null value";
            }
            catch (Exception ex)
            {
                return "An error has ocurred. " + ex.Message;
            }
        }
        public async Task ExecuteWithoutReturnAsync(string procedureName, DynamicParameters? param = null)
        {
            try
            {
                using (var sqlConnection = _context.CreateConnection())
                {
                    await sqlConnection.ExecuteAsync(procedureName, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
