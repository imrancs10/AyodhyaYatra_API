using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Repository.IRepository
{
    public interface IImageStoreRepository
    {
        Task<List<ImageStore>> GetImageStore(ModuleNameEnum moduleName, int moduleId, string imageType = "image");
        Task<List<ImageStore>> GetImageStore(Dictionary<ModuleNameEnum,List<int>> moduleNameAndIds, string imageType = "image");
        Task<List<ImageStore>> GetImageStore(ModuleNameEnum? moduleName, List<int> moduleIds, string imageType = "image");
        Task<List<ImageStore>> GetImageStore(ModuleNameEnum moduleName, int moduleId,int sequenceNo, string imageType = "image");
        Task<List<ImageStore>> GetImageStore(ModuleNameEnum? moduleName, List<int> moduleIds, bool allImage);
        Task<List<ImageStore>> GetImageStore(ModuleNameEnum moduleName, string fileType = "image");
        Task<List<ImageStoreWithName>> GetImageStore(ModuleNameEnum? moduleName,int pageNo,int pageSize, bool allImage = false, string imageType = "image");
        Task<ImageStore?> DeleteFile(int id);
    }
}
