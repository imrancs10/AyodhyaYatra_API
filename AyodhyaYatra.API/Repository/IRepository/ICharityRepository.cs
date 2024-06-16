using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Repository
{
    public interface ICharityRepository
    {
        Task<bool> AddCharityDataType(CharityMasterData request);
        Task<bool> UpdateCharityDataType(CharityMasterData request);
        Task<bool> DeleteCharityDataType(int id);
        Task<CharityMasterData> GetCharityDataType(int id);
        Task<PagingResponse<CharityMasterData>> GetAllCharityDataType(PagingRequest request);

        Task<bool> AddCharity(Charity request);
        Task<bool> UpdateCharity(Charity request);
        Task<bool> DeleteCharity(int id);
        Task<Charity> GetCharity(int id);
        Task<PagingResponse<Charity>> GetAllCharity(PagingRequest request);
    }
}
