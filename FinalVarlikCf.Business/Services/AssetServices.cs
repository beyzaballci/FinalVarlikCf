using FinalVarlikCf.Business.Interfaces;
using FinalVarlikCf.Models;
using FinalVarlikCf.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using FinalVarlikCf.Business.Interfaces;

namespace FinalVarlikCf.Business.Services
{
    public class AssetService : IAssetServices
    {
        private readonly IAssetRepository _repository;

        public AssetService(IAssetRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Asset>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Asset> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task CreateAsync(Asset asset) => _repository.CreateAsync(asset);
        public Task<bool> UpdateAsync(Asset asset) => _repository.UpdateAsync(asset);
        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}


