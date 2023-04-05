using Dapper;
using MaterialsManagement.DAL.DbContext;
using MaterialsManagement.DAL.Interfaces;
using MaterialsManagement.Model.Orders;
using MaterialsManagement.Model.Response;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MaterialsManagement.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MaterialsDbContext _dbContext;

        public OrderRepository(MaterialsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> FindByIdAsync(int id)
        {
            var linkapimaster = $"SELECT * FROM ordermaster where id={id}";
            var linkapidetail = $"SELECT * FROM orderdetail where orderdetail.order_id = {id}";
            using var conn = _dbContext.CreatePostgreSqlConnection();
            var cusMaster = await conn.QueryFirstOrDefaultAsync<Order>(linkapimaster);
            var cusDetail = await conn.QueryAsync<DetailsOrder>(linkapidetail);
            if(cusDetail != null)
            {
                cusMaster.Details = cusDetail.ToList();
            }
            return cusMaster;

        }

        public async Task<PagedResponse<IEnumerable<Order>>> GetPageAsync(FilterBase f)
        {
            //lấy data trong DB
            var storeProcedure = "sp_order_pages";
            using var conn = _dbContext.CreatePostgreSqlConnection();
            {
                var parameters = new DynamicParameters();
                parameters.Add("pageSize", f.PageSize);
                parameters.Add("pageNumber", f.PageNumber);
                parameters.Add("search", f.Search);
                parameters.Add("Total", 0, DbType.Int32, ParameterDirection.Output);
                var orders = await conn.QueryAsync<Order>(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
                var total = parameters.Get<int>("Total");
                var page = new PagedResponse<IEnumerable<Order>>(orders, f.PageNumber, total);
                return page;
            }
            //using var conn = _dbContext.CreatePostgreSqlConnection();
            //var cus = await conn.QueryAsync<Order>("SELECT * FROM ordermaster");
            ////dummy data
            //var customers = cus;
            //var page = new PagedResponse<IEnumerable<Order>>(customers, f.PageNumber, f.PageSize, customers.Count());
            //return page;
        }

        public async Task<Order> SaveAsync(Order order)
        {
            var sp = "order_set";
            using
                var conn = _dbContext.CreatePostgreSqlConnection();
            var param = new DynamicParameters();
            param.Add("id", order.Id);
            param.Add("code", order.Code);
            param.Add("create_date", order.Create_Date);
            param.Add("update_date", order.Update_Date);
            param.Add("amount", order.Amount);
            param.Add("note", order.Note);
            param.Add("cust_id", order.Cust_Id);
           
            var xml = new XElement("orders", from p in order.Details
                select new XElement("order",
                new XElement("id", p.Id),
                //new XElement("order_id", p.OrderId),
                new XElement("price", p.Price),
                new XElement("price_change", p.Price_Change),
                new XElement("quantity", p.Quantity),
                new XElement("amount", p.Amount),
                new XElement("create_date", p.Create_Date),
                new XElement("update_date", p.Update_Date),
                new XElement("note", p.Note),
                new XElement("material_id", p.Material_Id)
                )).ToString();

            param.Add("order_details", xml,DbType.Xml);
            await conn.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
            return order;
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            var sp = "order_update";
            using
                var conn = _dbContext.CreatePostgreSqlConnection();
            var param = new DynamicParameters();
            param.Add("order_id", order.Id);
            param.Add("code", order.Code);
            param.Add("_create_date", order.Create_Date);
            param.Add("_update_date", order.Update_Date);
            param.Add("_amount", order.Amount);
            param.Add("_note", order.Note);
            param.Add("cust_id", order.Cust_Id);

            var xml = new XElement("orders", from p in order.Details
                                             select new XElement("order",
                                             new XElement("id", p.Id),
                                             //new XElement("order_id", p.OrderId),
                                             new XElement("price", p.Price),
                                             new XElement("price_change", p.Price_Change),
                                             new XElement("quantity", p.Quantity),
                                             new XElement("amount", p.Amount),
                                             new XElement("create_date", p.Create_Date),
                                             new XElement("update_date", p.Update_Date),
                                             new XElement("note", p.Note),
                                             new XElement("material_id", p.Material_Id)
                                             )).ToString();

            param.Add("order_details", xml, DbType.Xml);
            await conn.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
            return order;
        }

        public async Task<Order> DeleteByCusIdAsync(int id)
        {
            using var conn = _dbContext.CreatePostgreSqlConnection();
            var cus = await conn.QueryFirstOrDefaultAsync<Order>($"SELECT * FROM customer where id={id}");
            string commandText = $"DELETE FROM customer WHERE id=(@p)";
            var queryArguments = new { p = id };
            await conn.ExecuteAsync(commandText, queryArguments);
            return cus;
        }



    }
}




