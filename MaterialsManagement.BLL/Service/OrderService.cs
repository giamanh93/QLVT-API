
using MaterialsManagement.BLL.Interfaces;
using MaterialsManagement.DAL.Interfaces;
using MaterialsManagement.DAL.Repository;
using MaterialsManagement.Model.Orders;
using MaterialsManagement.Model.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialsManagement.BLL.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<Order> FindByIdAsync(int id)
        {
            return _orderRepository.FindByIdAsync(id);
        }


        public Task<PagedResponse<IEnumerable<Order>>> GetPageAsync(FilterBase f)
        {
            return _orderRepository.GetPageAsync(f);
        }

        public Task<Order> SaveAsync(Order mode)
        {
            return _orderRepository.SaveAsync(mode);
        }

        public Task<Order> UpdateAsync(Order mode)
        {
            return _orderRepository.UpdateAsync(mode);
        }

        public Task<Order> DeleteByCusIdAsync(int id)
        {
            return _orderRepository.DeleteByCusIdAsync(id);
        }




    }
}
