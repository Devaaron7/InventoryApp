using InventoryApp.Models;
using System.Collections.Generic;
namespace InventoryApp.Data
{
    public interface IInventoryRepository
    {
        void AddItem(InventoryItem item);
        List<InventoryItem> GetItems();
    }
}
