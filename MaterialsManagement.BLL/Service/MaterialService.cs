
using MaterialsManagement.BLL.Interfaces;
using MaterialsManagement.DAL.Interfaces;
using MaterialsManagement.DAL.Repository;
using MaterialsManagement.Model.Materials;
using MaterialsManagement.Model.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialsManagement.BLL.Service
    {
        public class MaterialService : IMaterialService
    {
            private readonly IMaterialRepository _materialRepository;

            public MaterialService(IMaterialRepository materialRepository)
            {
            _materialRepository  = materialRepository;
            }

            public Task<Material> FindByIdAsync(int id)
            {
                return _materialRepository.FindByIdAsync(id);
            }


            public Task<PagedResponse<IEnumerable<Material>>> GetPageAsync(FilterBase f)
            {
                return _materialRepository.GetPageAsync(f);
            }

            public Task<Material> SaveAsync(Material mode)
            {
                return _materialRepository.SaveAsync(mode);
            }

            public Task<Material> UpdateAsync(Material mode)
            {
                return _materialRepository.UpdateAsync(mode);
            }

            public Task<Material> DeleteByCusIdAsync(int id)
            {
                return _materialRepository.DeleteByCusIdAsync(id);
            }




        }
    }
