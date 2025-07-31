using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalVarlikCf.Entity;
using FinalVarlikCf.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using FinalVarlikCf.DataAccess.Data;


namespace FinalVarlikCf.Repositories.Repositories
{
    public class AssetRepository : IAssetRepository

    {
        private readonly MyDbContext _context;

        public AssetRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _context.Assets.ToListAsync();
        }

        public async Task<Asset> GetByIdAsync(int id)
        {
            return await _context.Assets.FindAsync(id);
        }

        public async Task CreateAsync(Asset asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Asset asset)
        {
            var existing = await _context.Assets.FindAsync(asset.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(asset);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null) return false;

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
            return true;
        }
    }


}





