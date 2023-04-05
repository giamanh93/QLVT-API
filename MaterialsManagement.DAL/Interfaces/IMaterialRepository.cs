using MaterialsManagement.Model.Materials;
using MaterialsManagement.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialsManagement.DAL.Interfaces
{
    public interface IMaterialRepository
    {
        Task<Material> FindByIdAsync(int id);
        Task<PagedResponse<IEnumerable<Material>>> GetPageAsync(FilterBase f);
        Task<Material> SaveAsync(Material model);

        Task<Material> UpdateAsync(Material model);

        Task<Material> DeleteByCusIdAsync(int id);
    }
}
