using KaashiYatra.API.DTO.Request;
using KaashiYatra.API.DTO.Request.Common;
using KaashiYatra.API.DTO.Response;
using KaashiYatra.API.DTO.Response.Common;
using KaashiYatra.API.Models;

namespace KaashiYatra.API.Repository.IRepository
{
    public interface ITempleRepository
    {
        Task<Temple> AddTemple(Temple temple);
        Task<Temple> UpdateTemple(Temple temple);
        Task<bool> UpdateTemple(List<Temple> temples);
        Task<bool> DeleteTemple(int id);
        Task<Temple> GetTempleById(int id);
        Task<Temple> GetTempleById(string idorbarcodeId);
        Task<List<Temple>> GetTempleByYatraId(int yatraId,bool includeAllChildYatraTemple=false);
        Task<PagingResponse<Temple>> GetTemples(PagingRequest pagingRequest);
        Task<PagingResponse<Temple>> SearchTemples(SearchPagingRequest pagingRequest);
        Task<List<Temple>> GetTempleByPadavId(int padavId);
        Task<List<Temple>> GetTempleByYatraAndPadavId(int yatraId, int padavId);
        Task<List<int>> GetTempleIds();
        //Task<List<TempleCategory>> GetTempleCategory();

    }
}
