
using Dapper;
using MaterialsManagement.DAL.DbContext;
using MaterialsManagement.DAL.Interfaces;
using MaterialsManagement.Model.Materials;
using MaterialsManagement.Model.Response;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialsManagement.DAL.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly MaterialsDbContext _dbContext;
        
        public MaterialRepository(MaterialsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Material> FindByIdAsync(int id)
        {
            using var conn = _dbContext.CreatePostgreSqlConnection();
            var cus = await conn.QueryFirstOrDefaultAsync<Material>($"SELECT * FROM material where id={id}");
            return cus;
        }

        public async Task<PagedResponse<IEnumerable<Material>>> GetPageAsync(FilterBase f)
        {
            ////lấy data trong DB
            //var storeProcedure = "material_page";
            //using var conn = _dbContext.CreatePostgreSqlConnection();
            //{
            //    var parameters = new DynamicParameters();
            //    parameters.Add("pageSize", f.PageSize);
            //    parameters.Add("pageNumber", f.PageNumber);
            //    parameters.Add("search", f.Search);
            //    parameters.Add("Total", 0, DbType.Int32, ParameterDirection.Output);
            //    var materials = await conn.QueryAsync<Material>(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            //    var total = parameters.Get<int>("Total");
            //    var page = new PagedResponse<IEnumerable<Material>>(materials, f.PageNumber, total);
            //    return page;
            //}
            using var conn = _dbContext.CreatePostgreSqlConnection();
            var cus = await conn.QueryAsync<Material>("SELECT * FROM material");
            //dummy data
            var customers = cus;
            var page = new PagedResponse<IEnumerable<Material>>(customers, f.PageNumber, f.PageSize, customers.Count());
            return page;
        }

        public async Task<Material> SaveAsync(Material material)
        {
            var sp = "material_set";
            using
                var conn = _dbContext.CreatePostgreSqlConnection();
            var param = new DynamicParameters();
            param.Add("id", material.Id);
            param.Add("name", material.Name);
            param.Add("unit", material.Unit);
            param.Add("price_sell", material.Price_Sell);
            param.Add("total_weight", material.Total_Weight);
            param.Add("total_weight_sell", material.Total_Weight_Sell);
            param.Add("total_weight_renaining", material.Total_Weight_Renaining);
            param.Add("total_invest_amount", material.Total_Invest_Amount);
            param.Add("supplier", material.supplier);
            param.Add("price_buy", material.Price_Buy);
            param.Add("active", material.Active);
            param.Add("note", material.Note);

            await conn.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
            return material;
        }

        public async Task<Material> UpdateAsync(Material material)
        {
            var sp = "material_update";
            using
                var conn = _dbContext.CreatePostgreSqlConnection();
            var param = new DynamicParameters();
            param.Add("id", material.Id);
            param.Add("_name", material.Name);
            param.Add("_unit", material.Unit);
            param.Add("_price_sell", material.Price_Sell);
            param.Add("_total_weight", material.Total_Weight);
            param.Add("_total_weight_sell", material.Total_Weight_Sell);
            param.Add("_total_weight_renaining", material.Total_Weight_Renaining);
            param.Add("_total_invest_amount", material.Total_Invest_Amount);
            param.Add("_supplier", material.supplier);
            param.Add("_price_buy", material.Price_Buy);
            param.Add("_active", material.Active);
            param.Add("_note", material.Note);

            await conn.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
            return material;
        }

        public async Task<Material> DeleteByCusIdAsync(int id)
        {
            using var conn = _dbContext.CreatePostgreSqlConnection();
            var cus = await conn.QueryFirstOrDefaultAsync<Material>($"SELECT * FROM customer where id={id}");
            string commandText = $"DELETE FROM customer WHERE id=(@p)";
            var queryArguments = new { p = id };
            await conn.ExecuteAsync(commandText, queryArguments);
            return cus;
        }



    }
}




