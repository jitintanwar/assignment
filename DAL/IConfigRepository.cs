using DAL.Models;

namespace DAL
{
    public interface IConfigRepository
    {
        Task<ClientConfig> GetClientConfig(string clientName);

        Task<bool> SaveData(List<StandardDTO> data);
    }
}