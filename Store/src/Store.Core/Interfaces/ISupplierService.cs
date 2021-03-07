using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Interfaces
{
    public interface ISupplierService
    {
        Task<string> GetItemsAsync();
        Task<string> GetItemByCodeAsync(string code);
        Task<string> GetCategoriesAsync();
    }
}
