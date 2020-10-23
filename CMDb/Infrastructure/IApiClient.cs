using System.Threading.Tasks;

namespace CMDb.Infrastructure
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string endpoint);
    }
}