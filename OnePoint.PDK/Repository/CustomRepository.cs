using OnePoint.PDK.Models;
using OnePoint.PDK.Data;
using Dapper;

namespace OnePoint.PDK.Repository
{
    public class CustomRepository
    {
        private readonly OnePointDao _dao;
        public CustomRepository(OnePointDao dao)
        {
            _dao = dao;
        }

        public string GetCacheKey(CustomRepository entity, string key)
        {
            return $"{entity.GetType().Name}-{key}";
        }

        public async Task<ConsumerEntity> GetConsumerByName(string name)
        {
            var param = new DynamicParameters();
            param.Add("@Name", name, System.Data.DbType.AnsiString);
            var sql = $"SELECT Id,Name FROM Consumer WHERE Name = @Name ";
            var result = await _dao.ExecuteNonListAsync<ConsumerEntity>(sql, param, System.Data.CommandType.Text);
            return result;
        }

        public async Task<RouteEntity> GetRouteById(string id)
        {
            var param = new DynamicParameters();
            param.Add("@Id", id, System.Data.DbType.Int32);
            var sql = $"SELECT Id,Name,ClusterId FROM Routes WHERE Id = @Id ";
            var result = await _dao.ExecuteNonListAsync<RouteEntity>(sql, param, System.Data.CommandType.Text);
            return result;
        }

        public async Task<CACertificateEntity> GetCACertificateById(string id)
        {
            var param = new DynamicParameters();
            param.Add("@Id", id, System.Data.DbType.Int32);
            var sql = $"SELECT Id,Cert FROM CACertificates WHERE Id = @Id ";
            var result = await _dao.ExecuteNonListAsync<CACertificateEntity>(sql, param, System.Data.CommandType.Text);
            return result;
        }
    }
}
