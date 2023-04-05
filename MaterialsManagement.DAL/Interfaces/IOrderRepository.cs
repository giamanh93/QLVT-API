

using MaterialsManagement.Model.Orders;
using MaterialsManagement.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialsManagement.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> FindByIdAsync(int id);
        Task<PagedResponse<IEnumerable<Order>>> GetPageAsync(FilterBase f);
        Task<Order> SaveAsync(Order model);

        Task<Order> UpdateAsync(Order model);

        Task<Order> DeleteByCusIdAsync(int id);
    }
}
