using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlConfigRepopsitory : IConfigRepository // : DbContext
    {
        /*        
        private readonly DbContext dbContext;
        public SqlConfigRepopsitory(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        */

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
            //return await dbContext.ClientConfigs.FirstOrDefault(x => x.ClientName == clientName);

            var clientconfig = _clients.FirstOrDefault(x => x.ClientName == clientName);
            return await Task.FromResult(clientconfig);
        }

        public Task<bool> SaveData(List<StandardDTO> dataToSave)
        {
            // context.InventoryProducts.Add(dataToSave); context.SaveChanges() 

            return Task.FromResult(false);
        }
    }
}
