using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyodhyaYatra.API.Repositories
{
    public class FileStorageRepository : IFileStorageRepository
    {
        private readonly AyodhyaYatraContext _context;
        public FileStorageRepository(AyodhyaYatraContext context)
        {
            _context = context;
        }
        public async Task<List<ImageStore>> Add(List<ImageStore> ImageStores)
        {
            _context.ImageStores.AddRange(ImageStores);
            await _context.SaveChangesAsync();
            return ImageStores;
        }

        public async Task<int> Delete(int storageId)
        {
            ImageStore ImageStore = await _context.ImageStores.Where(fs => fs.Id == storageId).FirstOrDefaultAsync();
            _context.ImageStores.Remove(ImageStore);
            return await _context.SaveChangesAsync();
        }

        public async Task<ImageStore> Get(int storageId)
        {
            return await _context.ImageStores.Where(fs => fs.Id == storageId).FirstOrDefaultAsync();
        }

        public async Task<List<ImageStore>> GetByModuleIds(List<int> moduleIds, ModuleNameEnum moduleName)
        {
            try
            {
                return await _context.ImageStores
                    .Where(fs => moduleIds.Contains(fs.ModuleId) && fs.ModuleName.Equals(moduleName.ToString()))
                    .OrderByDescending(x=>x.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ImageStore>> GetByModuleName(ModuleNameEnum moduleName)
        {
            return await _context.ImageStores
                .Where(fs => fs.ModuleName.Equals(moduleName.ToString()))
                .ToListAsync();
        }

        public async Task<ImageStore> Update(ImageStore ImageStore)
        {
            EntityEntry<ImageStore> oldFileStorage = _context.Update(ImageStore);
            oldFileStorage.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return oldFileStorage.Entity;
        }
    }
}
