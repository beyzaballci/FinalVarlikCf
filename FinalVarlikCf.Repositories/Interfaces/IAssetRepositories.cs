using FinalVarlikCf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using FinalVarlikCf.Models;



namespace FinalVarlikCf.Repositories.Interfaces
{


    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAsync();
        Task<Asset> GetByIdAsync(int id);
        Task CreateAsync(Asset asset);
        Task<bool> UpdateAsync(Asset asset);
        Task<bool> DeleteAsync(int id);
    }



}

