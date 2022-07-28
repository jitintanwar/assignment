using DAL.Models;

namespace DAL
{
    public class SqlConfigRepopsitory : IConfigRepository // : DbContext
    {
        // this data is supposed to be coming from database. Making it in memory for now...

        List<ClientConfig> _clients = new List<ClientConfig>
        {
            new ClientConfig
            {
                ClientName = "capterra",
                ImportType ="yaml"
            },
            new ClientConfig
            {
                ClientName = "softwareadvice",
                ImportType = "json"
            }
        };
        

        public async Task<ClientConfig> GetClientConfig(string clientName)
        {
            var clientconfig = _clients.FirstOrDefault(x => x.ClientName == clientName);
            return await Task.FromResult(clientconfig);
        }        
    }
}
