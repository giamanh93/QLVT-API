using Dapper;
using MaterialsManagement.DAL.DbContext;
using MaterialsManagement.DAL.Interfaces;
using MaterialsManagement.Model.Customers;
using MaterialsManagement.Model.Response;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialsManagement.DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MaterialsDbContext _dbContext;
        private List<Customer> _customerList = new List<Customer>() {
                new Customer(1,"KH01","0123456789","HN",19000000,10000000,9000000,true, "ss"),
                new Customer(2,"KH02","0123456788","HN1",19000000,10000000,9000000,false, "ss"),
        };

        public CustomerRepository(MaterialsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> FindByIdAsync(int id)
        {
            using var conn = _dbContext.CreatePostgreSqlConnection();
            var cus = await conn.QueryFirstOrDefaultAsync<Customer>($"SELECT * FROM customer where id={id}");
            return cus;
        }

        public async Task<PagedResponse<IEnumerable<Customer>>> GetPageAsync(FilterBase f)
        {
            ////lấy data trong DB
            //var storeProcedure = "sp_customer_page";
            //using(var conn = _dbContext.CreateConnection())
            //{
            //    var parameters = new DynamicParameters();
            //    parameters.Add("pageSize", f.PageSize);
            //    parameters.Add("pageNumber", f.PageNumber);
            //    parameters.Add("search", f.Search);
            //    parameters.Add("Total", 0, DbType.Int32, ParameterDirection.Output);
            //    var customers = await conn.QueryAsync<Customer>(storeProcedure, parameters,commandType:CommandType.StoredProcedure);
            //    var total = parameters.Get<int>("Total");
            //    var page = new PagedResponse<IEnumerable<Customer>>(customers,f.PageNumber,total);
            //    return page;
            //}
            using var conn = _dbContext.CreatePostgreSqlConnection();
            var cus = await conn.QueryAsync<Customer>("SELECT * FROM customer");
            //dummy data
            var customers = cus;
            var page = new PagedResponse<IEnumerable<Customer>>(customers, f.PageNumber, f.PageSize, customers.Count());
            return page;
        }

        public async Task<Customer> SaveAsync(Customer customer)
        {
            var sp = "customer_set";
            using
                var conn = _dbContext.CreatePostgreSqlConnection();
            var param = new DynamicParameters();
            param.Add("id", customer.Id);
            param.Add("name", customer.Name);
            param.Add("phone", customer.Phone);
            param.Add("address", customer.Address);
            param.Add("total_purchase_amount", customer.Total_Purchase_Amount);
            param.Add("total_paid_amount", customer.Total_Paid_Amount);
            param.Add("total_debt_amount", customer.Total_Debt_Amount);
            param.Add("active", customer.Active);
            param.Add("note", customer.Note);
            await conn.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            var sp = "customer_update";
            using
                var conn = _dbContext.CreatePostgreSqlConnection();
            var param = new DynamicParameters();
            param.Add("id", customer.Id);
            param.Add("_name", customer.Name);
            param.Add("_phone", customer.Phone);
            param.Add("_address", customer.Address);
            param.Add("_total_purchase_amount", customer.Total_Purchase_Amount);
            param.Add("_total_paid_amount", customer.Total_Paid_Amount);
            param.Add("_total_debt_amount", customer.Total_Debt_Amount);
            param.Add("_active", customer.Active);
            param.Add("_note", customer.Note);

            await conn.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
            return customer;
        }

        public async Task<Customer> DeleteByCusIdAsync(int id)
        {
            using var conn = _dbContext.CreatePostgreSqlConnection();
            var cus = await conn.QueryFirstOrDefaultAsync<Customer>($"SELECT * FROM customer where id={id}");
            string commandText = $"DELETE FROM customer WHERE id=(@p)";
            var queryArguments = new { p = id };
            await conn.ExecuteAsync(commandText, queryArguments);
            return cus;
        }



    }
}




