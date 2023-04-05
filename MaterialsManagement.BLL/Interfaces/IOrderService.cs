
using MaterialsManagement.Model.Orders;
using MaterialsManagement.Model.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialsManagement.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<Order> FindByIdAsync(int id);
        Task<PagedResponse<IEnumerable<Order>>> GetPageAsync(FilterBase f);

        Task<Order> SaveAsync(Order cus);

        Task<Order> UpdateAsync(Order cus);

        Task<Order> DeleteByCusIdAsync(int id);
    }
}
