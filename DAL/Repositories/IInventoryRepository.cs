using DAL.Models;

namespace DAL
{
    public interface IInventoryRepository
    {
        Task<bool> UpdateInventory(List<ProductDTO> data);
    }
}
