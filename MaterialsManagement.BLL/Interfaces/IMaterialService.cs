


using MaterialsManagement.Model.Materials;
using MaterialsManagement.Model.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialsManagement.BLL.Interfaces
{
    public interface IMaterialService
    {
        Task<Material> FindByIdAsync(int id);
        Task<PagedResponse<IEnumerable<Material>>> GetPageAsync(FilterBase f);

        Task<Material> SaveAsync(Material cus);

        Task<Material> UpdateAsync(Material cus);

        Task<Material> DeleteByCusIdAsync(int id);
    }
}
