using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AyodhyaYatra.API.Repository
{
    public interface IFileStorageRepository
    {
        Task<List<ImageStore>> Add(List<ImageStore> ImageStores);
        Task<ImageStore> Update(ImageStore ImageStore);
        Task<int> Delete(int storageId);
        Task<ImageStore> Get(int storageId);
        Task<List<ImageStore>> GetByModuleIds(List<int> moduleIds, ModuleNameEnum moduleName);
        Task<List<ImageStore>> GetByModuleName(ModuleNameEnum moduleName);
    }
}
