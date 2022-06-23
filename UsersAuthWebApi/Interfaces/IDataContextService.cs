using Dapper;

namespace UsersAuthWebApi.Interfaces
{
    public interface IDataContextService
    {
        public Task<T> ReturnOneAsync<T>(string procedureName, DynamicParameters? param = null);
        public Task<IEnumerable<T>> ReturnListAsync<T>(string procedureName, DynamicParameters? param = null);
        public Task<string> ExecuteWithReturnAsync(string procedureName, DynamicParameters? param = null);
        public Task ExecuteWithoutReturnAsync(string procedureName, DynamicParameters? param = null);
    }
}
