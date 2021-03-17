using Store.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Interfaces
{
    public interface ISupplierService
    {
        Task<List<SupplierProductValueObject>> GetItemsAsync();
        Task<SupplierProductValueObject> GetItemByCodeAsync(string code);
        Task<List<SupplierCategoryValueObject>> GetCategoriesAsync();
    }
}
