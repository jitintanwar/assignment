using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlProductRepository : IInventoryRepository
    {
        public async Task<bool> UpdateInventory(List<ProductDTO> dataToSave)
        {
            return await Task.FromResult(false);
        }
    }
}
