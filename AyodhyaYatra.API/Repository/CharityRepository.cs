using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Exceptions;
using AyodhyaYatra.API.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;

namespace AyodhyaYatra.API.Repository
{
    public class CharityRepository : ICharityRepository
    {
        private readonly AyodhyaYatraContext _context;

        public CharityRepository(AyodhyaYatraContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCharity(Charity request)
        {
            var oldData = await _context.Charities
                .Where(x => !x.IsDeleted && x.CharityName==request.CharityName && x.CharityType==request.CharityType && x.CharityPurpose==request.CharityPurpose)
                .FirstOrDefaultAsync();

            if(oldData!=null)
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);
            }

            _context.Charities.Add(request);
            return await _context.SaveChangesAsync()>0;   
        }

        public async Task<bool> AddCharityDataType(CharityMasterData request)
        {
            var oldData = await _context.CharityMasterDatas
               .Where(x => !x.IsDeleted && x.Value == request.Value && x.DataType == request.DataType)
               .FirstOrDefaultAsync();

            if (oldData != null)
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);
            }

            _context.CharityMasterDatas.Add(request);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCharity(int id)
        {
            var oldData = await _context.Charities
               .Where(x => !x.IsDeleted && x.Id == id)
               .FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.IsDeleted = true;
            _context.Update(oldData);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCharityDataType(int id)
        {
            var oldData = await _context.CharityMasterDatas
                .Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.IsDeleted = true;
            _context.Update(oldData);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PagingResponse<Charity>> GetAllCharity(PagingRequest request)
        {
            var query = _context.Charities
                 .Where(x => !x.IsDeleted)
                 .OrderBy(x=>x.CharityName)
                 .AsQueryable();
            return new PagingResponse<Charity>()
            {
                Data = await query.Skip((request.PageNo - 1) * request.PageSize).Take(request.PageSize).ToListAsync(),
                TotalCount = await query.CountAsync(),
                PageSize = request.PageSize,
                PageNo = request.PageNo,
            };
        }

        public async Task<PagingResponse<CharityMasterData>> GetAllCharityDataType(PagingRequest request)
        {
            var query = _context.CharityMasterDatas
                 .Where(x => !x.IsDeleted)
                 .OrderBy(x => x.Value)
                 .AsQueryable();
            return new PagingResponse<CharityMasterData>()
            {
                Data = await query.Skip((request.PageNo - 1) * request.PageSize).Take(request.PageSize).ToListAsync(),
                TotalCount = await query.CountAsync(),
                PageSize = request.PageSize,
                PageNo = request.PageNo,
            };
        }

        public async Task<Charity> GetCharity(int id)
        {
            return await _context.Charities
                .Where(x=>!x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<CharityMasterData> GetCharityDataType(int id)
        {
            return await _context.CharityMasterDatas
                .Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateCharity(Charity request)
        {
            var oldData= await _context.Charities
                 .Where(x => !x.IsDeleted && x.Id == request.Id)
                 .FirstOrDefaultAsync()?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound,StaticValues.Error_RecordNotFound);

            oldData.CharityPurpose = request.CharityPurpose;
            oldData.Address = request.Address;
            oldData.CharityName = request.CharityName;
            oldData.CharityType= request.CharityType;
            oldData.Email = request.Email;
            oldData.Mobile= request.Mobile;

            _context.Update(oldData);
            return await _context.SaveChangesAsync()>0;

        }

        public async Task<bool> UpdateCharityDataType(CharityMasterData request)
        {
            var oldData = await _context.CharityMasterDatas
                 .Where(x => !x.IsDeleted && x.Id == request.Id)
                 .FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.DataType = request.DataType;
            oldData.Value = request.Value;

            _context.Update(oldData);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
