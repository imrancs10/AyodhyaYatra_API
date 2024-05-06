using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Exceptions;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository.IRepository;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AyodhyaYatra.API.Repository
{
    public class MasterAttractionTypeRepository : IMasterAttractionTypeRepository
    {
        private readonly AyodhyaYatraContext _context;
        public MasterAttractionTypeRepository(AyodhyaYatraContext context)
        {
            _context=context;
        }
        public async Task<int> Add(MasterAttractionType masterAttractionType)
        {
            if(masterAttractionType == null)
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_NoDataSupplied, StaticValues.Error_NoDataSupplied);
            }

            if(await _context.MasterAttractionTypes.Where(x=>!x.IsDeleted && x.Code==masterAttractionType.Code || x.Name == masterAttractionType.Name).AnyAsync())
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);
            }

            var entity=_context.MasterAttractionTypes.Add(masterAttractionType);
            return await _context.SaveChangesAsync()>0?entity.Entity.Id: 0;

        }

        public async Task<bool> Delete(int Id)
        {
            var data = await _context.MasterAttractionTypes.Where(x => x.Id == Id && !x.IsDeleted).FirstOrDefaultAsync()??throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            data.IsDeleted = false;
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<PagingResponse<MasterAttractionType>> GetAll(PagingRequest pagingRequest)
        {
            var data=_context.MasterAttractionTypes
                .Where(x=>!x.IsDeleted)
                .OrderBy(x=>x.Name)
                .AsQueryable();
            return new PagingResponse<MasterAttractionType>
            {
                PageNo = pagingRequest.PageNo,
                PageSize = pagingRequest.PageSize,
                Data =await data.Skip(pagingRequest.PageSize * (pagingRequest.PageNo - 1)).Take(pagingRequest.PageSize).ToListAsync(),
                TotalCount =await data.CountAsync()
            };
        }

        public async Task<MasterAttractionType> GetByCode(string code)
        {
           return await _context.MasterAttractionTypes
               .Where(x => !x.IsDeleted && x.Code==code)
               .OrderBy(x => x.Name)
               .FirstOrDefaultAsync();
        }

        public async Task<MasterAttractionType> GetById(int id)
        {
            return await _context.MasterAttractionTypes.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<MasterAttractionType>> Search(string searchTerm)
        {
           searchTerm= string.IsNullOrEmpty(searchTerm)?string.Empty:searchTerm;
            return await _context.MasterAttractionTypes
                .Where(x => !x.IsDeleted && (x.Code.Contains(searchTerm) || x.Name.Contains(searchTerm)))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<bool> Update(MasterAttractionType masterAttractionType)
        {
            var data = await _context.MasterAttractionTypes
                .Where(x => x.Id == masterAttractionType.Id && !x.IsDeleted).FirstOrDefaultAsync() ?? 
                throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            if(await _context.MasterAttractionTypes.Where(x=>!x.IsDeleted && x.Id!=masterAttractionType.Id && x.Code==masterAttractionType.Code).AnyAsync())
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_CodeIsAlreadyExist, StaticValues.Error_CodeIsAlreadyExist);
            }

            data.Name = masterAttractionType.Name;
            data.Code = masterAttractionType.Code;
            _context.MasterAttractionTypes.Update(data);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
