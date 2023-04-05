
using MaterialsManagement.BLL.Interfaces;
using MaterialsManagement.DAL.Interfaces;
using MaterialsManagement.Model.Customers;
using MaterialsManagement.Model.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialsManagement.BLL.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Customer> FindByIdAsync(int id)
        {
            return _customerRepository.FindByIdAsync(id);
        }
        

        public Task<PagedResponse<IEnumerable<Customer>>> GetPageAsync(FilterBase f)
        {
            return _customerRepository.GetPageAsync(f);
        }

        public Task<Customer> SaveAsync(Customer mode)
        {
            return _customerRepository.SaveAsync(mode);
        }

        public Task<Customer> UpdateAsync(Customer mode)
        {
            return _customerRepository.UpdateAsync(mode);
        }

        public Task<Customer> DeleteByCusIdAsync(int id)
        {
            return _customerRepository.DeleteByCusIdAsync(id);
        }




    }
}
