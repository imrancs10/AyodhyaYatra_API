using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Exceptions;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository.IRepository;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;

namespace AyodhyaYatra.API.Repository
{
    public class TempleRepository : ITempleRepository
    {
        private readonly AyodhyaYatraContext _context;

        public TempleRepository(AyodhyaYatraContext context)
        {
            _context = context;
        }
        public async Task<Temple> AddTemple(Temple temple)
        {
            try
            {
                var oldData = await _context.Temples
                         .Where(x => x.EnName == temple.EnName)
                         .FirstOrDefaultAsync();
                if (oldData != null)
                    throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);
                var entity = _context.Temples.Add(temple);
                entity.State = EntityState.Added;
                if (await _context.SaveChangesAsync() > 0)
                {
                    return entity.Entity;
                }
                return default(Temple);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeleteTemple(int id)
        {
            var oldData = await _context.Temples
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);
            if (oldData.IsDeleted)
                throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyDeleted, StaticValues.Error_AlreadyDeleted);
            oldData.IsDeleted = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Temple?> GetTempleById(int id)
        {
            return await _context.Temples
                .Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<Temple?> GetTempleById(string idorbarcodeId)
        {
            var IdValue = int.TryParse(idorbarcodeId, out int Id);
            return await _context.Temples
                .Where(x => !x.IsDeleted && x.Id == Id || x.TempleBarcodeId == idorbarcodeId)
                .FirstOrDefaultAsync();
        }
        public async Task<List<Temple>> GetTempleByYatraId(int yatraId, bool includeAllChildYatraTemple = false)
        {
            try
            {
                var subYatra = await _context.MasterYatras.Where(x => x.ParentYatraId == yatraId).ToListAsync();
                var result = await _context.Temples
                    .Include(x => x.Padav)
                    .Include(x => x.Yatra)
                 .Where(x => !x.IsDeleted && x.YatraId == yatraId)
                 .ToListAsync();
                if (includeAllChildYatraTemple)
                {
                    var suYatraIds = subYatra.Select(x => x.Id).ToList();
                    if (result.Count == 0 && subYatra.Count > 0)
                    {
                        result = await _context.Temples
                       .Include(x => x.Padav)
                       .Include(x => x.Yatra)
                    .Where(x => !x.IsDeleted && suYatraIds.Contains(x.YatraId ?? 0))
                    .ToListAsync();
                    }
                }
                else
                {
                    if (result.Count == 0 && subYatra.Count > 0)
                    {
                        result = await _context.Temples
                       .Include(x => x.Padav)
                       .Include(x => x.Yatra)
                    .Where(x => !x.IsDeleted && x.YatraId == subYatra.FirstOrDefault().Id)
                    .ToListAsync();
                    }
                }
                result.ForEach(res => res.Yatra.Temples = null);
                if (yatraId == 11)
                {
                    var dic = result.ToDictionary(x => int.Parse(x.SequenceNo.Split("-")[1]), y => y);
                    List<Temple> newResponse = new();
                    for (int i = 0; i <= 150; i++)
                    {
                        if (dic.Keys.Contains(i))
                            newResponse.Add(dic[i]);
                    }
                    return newResponse;
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<Temple>> GetTempleByPadavId(int padavId)
        {
            try
            {
                var result = await _context.Temples
                    .Include(x => x.Padav)
                    .Include(x => x.Yatra)
                 .Where(x => !x.IsDeleted && x.PadavId == padavId)
                 .ToListAsync();
                result.ForEach(res => res.Yatra.Temples = null);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<Temple>> GetTempleByYatraAndPadavId(int yatraId, int padavId)
        {
            try
            {
                var result = await _context.Temples
                    .Include(x => x.Padav)
                    .Include(x => x.Yatra)
                 .Where(x => !x.IsDeleted && x.YatraId == yatraId && x.PadavId == padavId)
                 .ToListAsync();
                result.ForEach(res => res.Yatra.Temples = null);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<PagingResponse<Temple>> GetTemples(PagingRequest pagingRequest)
        {
            var data = await _context.Temples
              .Where(x => !x.IsDeleted)
              .OrderBy(x => x.EnName)
              .ToListAsync();
            return new PagingResponse<Temple>
            {
                PageNo = pagingRequest.PageNo,
                PageSize = pagingRequest.PageSize,
                Data = data.Skip(pagingRequest.PageSize * (pagingRequest.PageNo - 1)).Take(pagingRequest.PageSize).ToList(),
                TotalCount = data.Count
            };
        }

        public async Task<PagingResponse<Temple>> SearchTemples(SearchPagingRequest pagingRequest)
        {
            var data = await _context.Temples
              .Where(x => !x.IsDeleted && (
                  string.IsNullOrEmpty(pagingRequest.SearchTerm) ||
                  x.EnName.Contains(pagingRequest.SearchTerm) ||
                  x.HiName.Contains(pagingRequest.SearchTerm) ||
                  x.SequenceNo.Contains(pagingRequest.SearchTerm) ||
                  x.EnDescription.Contains(pagingRequest.SearchTerm) ||
                  x.HiDescription.Contains(pagingRequest.SearchTerm) ||
                  x.Latitude.Contains(pagingRequest.SearchTerm) ||
                  x.Longitude.Contains(pagingRequest.SearchTerm)
              ))
              .OrderBy(x => x.EnName)
              .ToListAsync();
            return new PagingResponse<Temple>
            {
                PageNo = pagingRequest.PageNo,
                PageSize = pagingRequest.PageSize,
                Data = data.Skip(pagingRequest.PageSize * (pagingRequest.PageNo - 1)).Take(pagingRequest.PageSize).ToList(),
                TotalCount = data.Count
            };
        }

        public async Task<Temple> UpdateTemple(Temple temple)
        {
            var oldData = await _context.Temples
               .Where(x => x.Id == temple.Id)
               .FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);
            if (oldData.IsDeleted)
                throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyDeleted, StaticValues.Error_AlreadyDeleted);
            oldData.EnDescription = temple.EnDescription;
            oldData.EnName = temple.EnName;
            oldData.HiName = temple.HiName;
            oldData.YatraId = temple.YatraId;
            oldData.PadavId = temple.PadavId;
            oldData.SequenceNo = temple.SequenceNo;
            oldData.EnDescription = temple.EnDescription;
            oldData.HiDescription = temple.HiDescription;
            oldData.Longitude = temple.Longitude;
            oldData.Latitude = temple.Latitude;
            oldData.TempleCategoryId = temple.TempleCategoryId;
            oldData.TempleURL = temple.TempleURL;
            oldData.Temple360DegreeVideoURL = temple.Temple360DegreeVideoURL;
            oldData.TaName = temple.TaName;
            oldData.TeName = temple.TeName;
            oldData.TaDescription = temple.TaDescription;
            oldData.TeDescription = temple.TeDescription;
            if (await _context.SaveChangesAsync() > 0)
                return temple;
            return default(Temple);
        }

        public async Task<List<int>> GetTempleIds()
        {
            return await _context.Temples
                .Where(x => !x.IsDeleted)
                .Select(x => x.Id).ToListAsync();
        }

        public async Task<bool> UpdateTemple(List<Temple> temples)
        {
            var ids=temples.Where(x=>x.Id!=0).Select(x => x.Id).ToList();
            var dic = temples.Where(x => x.Id != 0).ToDictionary(x => x.Id, y => y);
            var oldData=await _context.Temples.Where(x=>!x.IsDeleted && ids.Contains(x.Id)).ToListAsync();
            foreach(var data in oldData)
            {
                if(dic.ContainsKey(data.Id))
                {
                    if (!string.IsNullOrEmpty(dic[data.Id].HiDescription))
                        data.HiDescription = dic[data.Id].HiDescription;

                    if (!string.IsNullOrEmpty(dic[data.Id].HiName))
                        data.HiName = dic[data.Id].HiName;

                    if (!string.IsNullOrEmpty(dic[data.Id].Latitude))
                        data.Latitude = dic[data.Id].Latitude;

                    if (!string.IsNullOrEmpty(dic[data.Id].Longitude))
                        data.Longitude = dic[data.Id].Longitude;

                    if (!string.IsNullOrEmpty(dic[data.Id].SequenceNo))
                        data.SequenceNo = dic[data.Id].SequenceNo;

                    if (!string.IsNullOrEmpty(dic[data.Id].EnDescription))
                        data.EnDescription = dic[data.Id].EnDescription;

                    if (!string.IsNullOrEmpty(dic[data.Id].EnName))
                        data.EnName = dic[data.Id].EnName;

                    if (!string.IsNullOrEmpty(dic[data.Id].TaDescription))
                        data.TaDescription = dic[data.Id].TaDescription;

                    if (!string.IsNullOrEmpty(dic[data.Id].TaName))
                        data.TaName = dic[data.Id].TaName;

                    if (!string.IsNullOrEmpty(dic[data.Id].TeName))
                        data.TeName = dic[data.Id].TeName;

                    if (!string.IsNullOrEmpty(dic[data.Id].TeDescription))
                        data.TeDescription = dic[data.Id].TeDescription;
                }
            }
            _context.Temples.UpdateRange(oldData);
            return await _context.SaveChangesAsync() > 0;
        }
        //public async Task<List<TempleCategory>> GetTempleCategory()
        //{
        //    try
        //    {
        //        var data = await _context.TempleCategory
        //    .Where(x => !x.IsDeleted)
        //    .OrderBy(x => x.Id)
        //    .ToListAsync();
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}

    }
}
