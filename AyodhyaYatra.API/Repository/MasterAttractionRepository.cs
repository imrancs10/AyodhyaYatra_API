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
    public class MasterAttractionRepository : IMasterAttractionRepository
    {
        private readonly AyodhyaYatraContext _context;

        public MasterAttractionRepository(AyodhyaYatraContext context)
        {
            _context = context;
        }
        public async Task<MasterAttraction> AddMasterAttraction(MasterAttraction MasterAttraction)
        {
            try
            {
                var oldData = await _context.MasterAttractions
                         .Where(x => x.EnName == MasterAttraction.EnName)
                         .FirstOrDefaultAsync();
                if (oldData != null)
                    throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);
                var entity = _context.MasterAttractions.Add(MasterAttraction);
                entity.State = EntityState.Added;
                if (await _context.SaveChangesAsync() > 0)
                {
                    return entity.Entity;
                }
                return default(MasterAttraction);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeleteMasterAttraction(int id)
        {
            var oldData = await _context.MasterAttractions
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);
            if (oldData.IsDeleted)
                throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyDeleted, StaticValues.Error_AlreadyDeleted);
            oldData.IsDeleted = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<MasterAttraction?> GetMasterAttractionById(int id)
        {
            return await _context.MasterAttractions
                .Include(x => x.MasterAttractionType)
                .Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<MasterAttraction?> GetMasterAttractionById(string idorbarcodeId)
        {
            var IdValue = int.TryParse(idorbarcodeId, out int Id);
            return await _context.MasterAttractions
                .Where(x => !x.IsDeleted && x.Id == Id || x.BarcodeId == idorbarcodeId)
                .FirstOrDefaultAsync();
        }
        public async Task<List<YatraAttractionMapper>> GetMasterAttractionByYatraId(int yatraId)
        {
            try
            {
                return await _context.YatraAttractionMappers
                    .Include(x => x.MasterYatra)
                    .Include(x => x.MasterAttraction)
                    .Where(x => x.YatraId == yatraId && !x.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                return default;
            }
        }
        public async Task<PagingResponse<MasterAttraction>> GetMasterAttractions(PagingRequest pagingRequest)
        {
            var data = await _context.MasterAttractions
                .Include(x => x.MasterAttractionType)
              .Where(x => !x.IsDeleted)
              .OrderBy(x => x.EnName)
              .ToListAsync();
            return new PagingResponse<MasterAttraction>
            {
                PageNo = pagingRequest.PageNo,
                PageSize = pagingRequest.PageSize,
                Data = data.Skip(pagingRequest.PageSize * (pagingRequest.PageNo - 1)).Take(pagingRequest.PageSize).ToList(),
                TotalCount = data.Count
            };
        }

        public async Task<List<MasterAttraction>> GetMasterAttractionByTypeId(int typeId)
        {
            var data = await _context.MasterAttractions
                .Include(x => x.MasterAttractionType)
              .Where(x => !x.IsDeleted && x.AttractionTypeId == typeId)
              .OrderBy(x => x.EnName)
              .ToListAsync();
            return data;
        }

        public async Task<List<MasterAttraction>> GetSpecificMasterAttraction()
        {
            var data = new List<MasterAttraction>();
            //temple
            var dataTemple = await _context.MasterAttractions
                .Include(x => x.MasterAttractionType)
              .Where(x => !x.IsDeleted && x.AttractionTypeId == 10 && x.Id == 133)
              .ToListAsync();

            //Bhawan
            var dataBhawan = await _context.MasterAttractions
                .Include(x => x.MasterAttractionType)
              .Where(x => !x.IsDeleted && x.AttractionTypeId == 4)
              .Take(1)
              .ToListAsync();

            //kund
            var dataKund = await _context.MasterAttractions
                .Include(x => x.MasterAttractionType)
              .Where(x => !x.IsDeleted && x.AttractionTypeId == 3)
              .Take(1)
              .ToListAsync();

            //Ashram
            var dataAshram = await _context.MasterAttractions
                .Include(x => x.MasterAttractionType)
              .Where(x => !x.IsDeleted && x.AttractionTypeId == 5)
              .Take(1)    
              .ToListAsync();

            //Ghat
            var dataGhat = await _context.MasterAttractions
                .Include(x => x.MasterAttractionType)
              .Where(x => !x.IsDeleted && x.AttractionTypeId == 2)
              .Take(1)
              .ToListAsync();

            data = dataTemple.Union(dataGhat).Union(dataAshram).Union(dataKund).Union(dataBhawan).ToList();

            return data;
        }

        public async Task<PagingResponse<MasterAttraction>> SearchMasterAttractions(SearchPagingRequest pagingRequest)
        {
            var data = await _context.MasterAttractions
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
            return new PagingResponse<MasterAttraction>
            {
                PageNo = pagingRequest.PageNo,
                PageSize = pagingRequest.PageSize,
                Data = data.Skip(pagingRequest.PageSize * (pagingRequest.PageNo - 1)).Take(pagingRequest.PageSize).ToList(),
                TotalCount = data.Count
            };
        }

        public async Task<MasterAttraction> UpdateMasterAttraction(MasterAttraction MasterAttraction)
        {
            var oldData = await _context.MasterAttractions
               .Where(x => x.Id == MasterAttraction.Id)
               .FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);
            if (oldData.IsDeleted)
                throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyDeleted, StaticValues.Error_AlreadyDeleted);
            oldData.EnDescription = MasterAttraction.EnDescription;
            oldData.EnName = MasterAttraction.EnName;
            oldData.HiName = MasterAttraction.HiName;
            oldData.SequenceNo = MasterAttraction.SequenceNo;
            oldData.EnDescription = MasterAttraction.EnDescription;
            oldData.HiDescription = MasterAttraction.HiDescription;
            oldData.Longitude = MasterAttraction.Longitude;
            oldData.Latitude = MasterAttraction.Latitude;
            oldData.AttractionURL = MasterAttraction.AttractionURL;
            oldData.Video360URL = MasterAttraction.Video360URL;
            oldData.TaName = MasterAttraction.TaName;
            oldData.TeName = MasterAttraction.TeName;
            oldData.TaDescription = MasterAttraction.TaDescription;
            oldData.TeDescription = MasterAttraction.TeDescription;
            if (await _context.SaveChangesAsync() > 0)
                return MasterAttraction;
            return default(MasterAttraction);
        }

        public async Task<List<int>> GetMasterAttractionIds()
        {
            return await _context.MasterAttractions
                .Where(x => !x.IsDeleted)
                .Select(x => x.Id).ToListAsync();
        }

        public async Task<bool> UpdateMasterAttraction(List<MasterAttraction> MasterAttractions)
        {
            var ids = MasterAttractions.Where(x => x.Id != 0).Select(x => x.Id).ToList();
            var dic = MasterAttractions.Where(x => x.Id != 0).ToDictionary(x => x.Id, y => y);
            var oldData = await _context.MasterAttractions.Where(x => !x.IsDeleted && ids.Contains(x.Id)).ToListAsync();
            foreach (var data in oldData)
            {
                if (dic.ContainsKey(data.Id))
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
            _context.MasterAttractions.UpdateRange(oldData);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> DeleteMasterAttration(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<MasterAttractionCategory>> GetMasterAttractionCategory()
        //{
        //    try
        //    {
        //        var data = await _context.MasterAttractionCategory
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
