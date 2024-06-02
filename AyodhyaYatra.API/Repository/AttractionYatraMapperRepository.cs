using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Exceptions;
using AyodhyaYatra.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AyodhyaYatra.API.Repository
{
    public class AttractionYatraMapperRepository : IAttractionYatraMapperRepository
    {
        private readonly AyodhyaYatraContext _context;
        public AttractionYatraMapperRepository(AyodhyaYatraContext context)
        {
            _context = context;
        }
        public async Task<int> Add(YatraAttractionMapper yatraAttractionMapper)
        {
            if (yatraAttractionMapper == null)
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_NoDataSupplied, StaticValues.Error_NoDataSupplied);
            }

            if (await _context.YatraAttractionMappers.Where(x => !x.IsDeleted && x.YatraId == yatraAttractionMapper.YatraId && x.MasterAttractionId == yatraAttractionMapper.MasterAttractionId).AnyAsync())
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);
            }

            var entity = _context.YatraAttractionMappers.Add(yatraAttractionMapper);
            return await _context.SaveChangesAsync() > 0 ? entity.Entity.Id : 0;

        }

        public async Task<bool> Delete(int Id)
        {
            var data = await _context.YatraAttractionMappers
                .Where(x => x.Id == Id && !x.IsDeleted)
                .FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            data.IsDeleted = true;
            _context.Update(data);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<PagingResponse<YatraAttractionMapper>> GetAll(PagingRequest pagingRequest)
        {
            var data = _context.YatraAttractionMappers
                .Include(x => x.MasterYatra)
                .Include(x => x.MasterAttraction)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.YatraId)
                .ThenBy(x=>x.DisplayOrder)
                .AsQueryable();
            return new PagingResponse<YatraAttractionMapper>
            {
                PageNo = pagingRequest.PageNo,
                PageSize = pagingRequest.PageSize,
                Data = await data.Skip(pagingRequest.PageSize * (pagingRequest.PageNo - 1)).Take(pagingRequest.PageSize).ToListAsync(),
                TotalCount = await data.CountAsync()
            };
        }

        public async Task<YatraAttractionMapper> GetById(int id)
        {
            return await _context.YatraAttractionMappers
                .Include(x => x.MasterYatra)
                .Include(x => x.MasterAttraction)
                .Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<YatraAttractionMapper>> GetByYatraId(int yatraId)
        {
            return await _context.YatraAttractionMappers
            .Include(x => x.MasterYatra)
            .Include(x => x.MasterAttraction)
            .Where(x => !x.IsDeleted && x.YatraId==yatraId)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync();
        }

        public async Task<PagingResponse<YatraAttractionMapper>> Search(SearchPagingRequest request)
        {
            request.SearchTerm = string.IsNullOrEmpty(request.SearchTerm) ? "all" : request.SearchTerm;
            var query= _context.YatraAttractionMappers
                .Include(x=>x.MasterYatra)
                .Include(x=>x.MasterAttraction)
                .Where(x => !x.IsDeleted && (request.SearchTerm=="all" || x.MasterAttraction.EnName.Contains(request.SearchTerm) || x.MasterYatra.EnName.Contains(request.SearchTerm)))
                .OrderBy(x => x.DisplayOrder)
                .AsQueryable();

            return new PagingResponse<YatraAttractionMapper>
            {
                PageNo = request.PageNo,
                PageSize = request.PageSize,
                Data = await query.Skip(request.PageSize * (request.PageNo - 1)).Take(request.PageSize).ToListAsync(),
                TotalCount = await query.CountAsync()
            };
        }

        public async Task<bool> Update(YatraAttractionMapper yatraAttractionMapper)
        {
            var data = await _context.YatraAttractionMappers
                .Where(x => x.Id == yatraAttractionMapper.Id && !x.IsDeleted).FirstOrDefaultAsync() ??
                throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            if (await _context.YatraAttractionMappers.Where(x => !x.IsDeleted && x.YatraId != yatraAttractionMapper.YatraId && x.MasterAttractionId == yatraAttractionMapper.MasterAttractionId).AnyAsync())
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_CodeIsAlreadyExist, StaticValues.Error_CodeIsAlreadyExist);
            }

            data.YatraId = yatraAttractionMapper.YatraId;
            data.MasterAttractionId = yatraAttractionMapper.MasterAttractionId;
            _context.YatraAttractionMappers.Update(data);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
