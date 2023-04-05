using MaterialsManagement.Model.Customers;
using MaterialsManagement.Model.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialsManagement.BLL.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> FindByIdAsync(int id);
        Task<PagedResponse<IEnumerable<Customer>>> GetPageAsync(FilterBase f);

        Task<Customer> SaveAsync(Customer cus); 

        Task<Customer> UpdateAsync(Customer cus);

        Task<Customer> DeleteByCusIdAsync(int id);
    }
}
