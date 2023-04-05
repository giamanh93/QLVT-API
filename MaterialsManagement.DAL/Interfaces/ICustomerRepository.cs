using MaterialsManagement.Model.Customers;
using MaterialsManagement.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialsManagement.DAL.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> FindByIdAsync(int id);
        Task<PagedResponse<IEnumerable<Customer>>> GetPageAsync(FilterBase f); 
        Task<Customer> SaveAsync(Customer model);

        Task<Customer> UpdateAsync(Customer model);

        Task<Customer> DeleteByCusIdAsync(int id);
    }
}
