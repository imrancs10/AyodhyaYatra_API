using AutoMapper;
using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.DTO.Response.Common;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Exceptions;
using AyodhyaYatra.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AyodhyaYatra.API.Repository
{
    public class MasterDataRepository : IMasterDataRepository
    {
        #region Private Members
        private AyodhyaYatraContext _context;
        private IMapper _mapper;

        #endregion

        #region CTOR

        public MasterDataRepository(AyodhyaYatraContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods

        public async Task<List<MasterYatra>> GetYatras()
        {
            return await _context.MasterYatras
               .Where(x => !x.IsDeleted)
               .OrderBy(x => x.EnName)
               .ToListAsync();
        }
        public async Task<MasterYatra?> GetYatraById(int id)
        {
            return await _context.MasterYatras
                .Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<MasterYatra> AddYatras(MasterYatra request)
        {
            var oldData = await _context.MasterYatras.Where(x => !x.IsDeleted && x.EnName == request.EnName).FirstOrDefaultAsync();
            if (oldData != null) throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);

            var entity = _context.MasterYatras.Add(request);
            entity.State = EntityState.Added;
            if (await _context.SaveChangesAsync() > 0) return entity.Entity;
            return default(MasterYatra);
        }

        public async Task<bool> DeleteDivisions(int id)
        {
            var oldData = await _context.MasterYatras.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.IsDeleted = true;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteYatras(int id)
        {
            var oldData = await _context.MasterYatras.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if (oldData == null) throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.IsDeleted = true;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<MasterDataExt>> GetMasterData(ModuleNameEnum masterDataType)
        {
            if (masterDataType == ModuleNameEnum.MasterAttraction)
            {
                var data = await _context.MasterAttractions.Where(x => !x.IsDeleted).OrderBy(x => x.EnName).ToListAsync();
                return _mapper.Map<List<MasterDataExt>>(data);
            }
            else
            {
                var data = await _context.MasterDatas.Where(x => !x.IsDeleted && x.MasterDataType == masterDataType).OrderBy(x => x.EnName).ToListAsync();
                return _mapper.Map<List<MasterDataExt>>(data);
            }
        }

        public async Task<int> AddMasterData(MasterData request)
        {
            int result = 0;
            try
            {
                var oldData = await _context.MasterDatas.Where(x => !x.IsDeleted && x.MasterDataType == request.MasterDataType && x.EnName == request.EnName).CountAsync();
                if (oldData > 0) throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);

                _context.MasterDatas.Add(request);
                result = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<int> DeleteMasterData(int id)
        {
            var oldData = await _context.MasterDatas.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.IsDeleted = true;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<MasterData> GetMasterData(int id)
        {
            return await _context.MasterDatas.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateMasterData(MasterData masterData)
        {
            var oldData = await _context.MasterDatas.Where(x => !x.IsDeleted && x.Id == masterData.Id).FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            oldData.IsDeleted = false;
            oldData.EnDescription = masterData.EnDescription;
            oldData.HiDescription = masterData.HiDescription;
            oldData.MasterDataType = masterData.MasterDataType;
            oldData.EnName = masterData.EnName;
            oldData.HiName = masterData.HiName;
            oldData.Latitude = masterData.Latitude;
            oldData.Longitude = masterData.Longitude;
            oldData.TaName = masterData.TaName;
            oldData.TeName = masterData.TeName;
            oldData.TaDescription = masterData.TaDescription;
            oldData.TeDescription = masterData.TeDescription;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateYatra(MasterYatra masterData)
        {
            var oldData = await _context.MasterYatras.Where(x => !x.IsDeleted && x.Id == masterData.Id).FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);

            //oldData.IsDeleted = true;
            oldData.EnDescription = masterData.EnDescription;
            oldData.HiDescription = masterData.HiDescription;
            oldData.EnName = masterData.EnName;
            oldData.HiName = masterData.HiName;
            oldData.TaDescription = masterData.TaDescription;
            oldData.TeDescription = masterData.TeDescription;
            oldData.TaName = masterData.TaName;
            oldData.TeName = masterData.TeName;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<MasterDataExt>> GetMasterDataNearByPlacesPath(MasterNearByPlacesRequest request)
        {
            var MasterAttraction = await _context.MasterAttractions.Where(x => !x.IsDeleted).OrderBy(x => x.EnName).ToListAsync();
            var MasterAttractionData = _mapper.Map<List<MasterDataExt>>(MasterAttraction);
            MasterAttractionData.ForEach(x => x.MasterDataType = ModuleNameEnum.MasterAttraction);

            var master = await _context.MasterDatas.Where(x => !x.IsDeleted).OrderBy(x => x.EnName).ToListAsync();
            var masterData = _mapper.Map<List<MasterDataExt>>(master);
            masterData.ForEach(x => x.MasterDataType = x.MasterDataType);

            var data = MasterAttractionData.Union(masterData).ToList();

            var result = await CalculateDistance(data, request.NearByRangeInKM, Convert.ToDouble(request.Latitude), Convert.ToDouble(request.Longitude));

            var masterTransport = await _context.MasterDatas.Where(x => !x.IsDeleted && (x.MasterDataType == ModuleNameEnum.Railways || x.MasterDataType == ModuleNameEnum.Transport)).OrderBy(x => x.EnName).ToListAsync();
            var masterDataTransport = _mapper.Map<List<MasterDataExt>>(masterTransport);
            result = result.Union(masterDataTransport).ToList();
            return result;
        }
        public async Task<List<MasterDataExt>> CalculateDistance(List<MasterDataExt> allMasterData, double? NearByRangeInKM, double startLat, double startLng)
        {
            double EarthRadius = 6371; // in kilometers
            double lat1Radians = DegreesToRadians(startLat);
            double lng1Radians = DegreesToRadians(startLng);
            var result = new List<MasterDataExt>();
            foreach (var masterData in allMasterData)
            {
                if (masterData.Latitude != null && masterData.Longitude != null)
                {
                    double endLat = Convert.ToDouble(masterData.Latitude);
                    double endLng = Convert.ToDouble(masterData.Longitude);
                    double lat2Radians = DegreesToRadians(endLat);
                    double lng2Radians = DegreesToRadians(endLng);
                    double latDiff = lat2Radians - lat1Radians;
                    double lngDiff = lng2Radians - lng1Radians;
                    double a = Math.Sin(latDiff / 2) * Math.Sin(latDiff / 2) + Math.Cos(lat1Radians) * Math.Cos(lat2Radians) * Math.Sin(lngDiff / 2) * Math.Sin(lngDiff / 2);
                    double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                    double distance = EarthRadius * c;
                    if (distance <= NearByRangeInKM)
                    {
                        var data = _mapper.Map<MasterDataExt>(masterData);
                        data.DistanceInKM = distance;
                        result.Add(data);
                    }

                }

            }

            return result;
        }
        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
        public async Task<PagingResponse<MasterData>> SearchMasterData(SearchPagingRequest pagingRequest)
        {
            var data = await _context.MasterDatas
              .Where(x => !x.IsDeleted && (
                  string.IsNullOrEmpty(pagingRequest.SearchTerm) ||
                  x.EnName.Contains(pagingRequest.SearchTerm) ||
                  x.HiName.Contains(pagingRequest.SearchTerm) ||
                  x.EnDescription.Contains(pagingRequest.SearchTerm) ||
                  x.HiDescription.Contains(pagingRequest.SearchTerm) ||
                  x.Latitude.Contains(pagingRequest.SearchTerm) ||
                  x.Longitude.Contains(pagingRequest.SearchTerm)
              )).OrderBy(x => x.MasterDataType).ToListAsync();

            var MasterAttraction = await _context.MasterAttractions.Where(x => !x.IsDeleted &&
                (string.IsNullOrEmpty(pagingRequest.SearchTerm) ||
                  x.EnName.Contains(pagingRequest.SearchTerm) ||
                  x.HiName.Contains(pagingRequest.SearchTerm) ||
                  x.EnDescription.Contains(pagingRequest.SearchTerm) ||
                  x.HiDescription.Contains(pagingRequest.SearchTerm) ||
                  x.Latitude.Contains(pagingRequest.SearchTerm) ||
                  x.Longitude.Contains(pagingRequest.SearchTerm)
              )).OrderBy(x => x.EnName).ToListAsync();
            var MasterAttractionData = _mapper.Map<List<MasterData>>(MasterAttraction);
            MasterAttractionData.ForEach(x => x.MasterDataType = ModuleNameEnum.MasterAttraction);

            data = data.Union(MasterAttractionData).ToList();

            return new PagingResponse<MasterData>
            {
                PageNo = pagingRequest.PageNo,
                PageSize = pagingRequest.PageSize,
                Data = data.Skip(pagingRequest.PageSize * (pagingRequest.PageNo - 1)).Take(pagingRequest.PageSize).ToList(),
                TotalCount = data.Count
            };
        }

        public async Task<List<MasterDataExt>> GetMasterData(List<ModuleNameEnum> masterDataTypes)
        {
            var resp = new List<MasterDataExt>();
            if (masterDataTypes.Contains(ModuleNameEnum.MasterAttraction))
            {
                var data = await _context.MasterAttractions.Where(x => !x.IsDeleted).OrderBy(x => x.EnName).ToListAsync();
                resp.AddRange(_mapper.Map<List<MasterDataExt>>(data));
            }
            else if (masterDataTypes.Contains(ModuleNameEnum.MasterAttraction))
            {
                var data = await _context.MasterYatras.Where(x => !x.IsDeleted).OrderBy(x => x.EnName).ToListAsync();
                resp.AddRange(_mapper.Map<List<MasterDataExt>>(data));
            }
            else
            {
                var data = await _context.MasterDatas.Where(x => !x.IsDeleted && masterDataTypes.Contains(x.MasterDataType)).OrderBy(x => x.EnName).ToListAsync();
                resp.AddRange(_mapper.Map<List<MasterDataExt>>(data));
            }
            return resp;
        }
        #endregion

    }
}
