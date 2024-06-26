﻿using AutoMapper;
using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.Enums;
using AyodhyaYatra.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AyodhyaYatra.API.Repository
{
    public class ImageStoreRepository : IImageStoreRepository
    {
        private readonly AyodhyaYatraContext _context;
        private readonly IMapper _mapper;

        public ImageStoreRepository(AyodhyaYatraContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ImageStore?> DeleteFile(int id)
        {
            var oldData = await _context.ImageStores.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (oldData == null)
                return null;
            _context.ImageStores.Remove(oldData);
            if (await _context.SaveChangesAsync() > 0)
                return oldData;
            return null;
        }

        public async Task<List<ImageStore>> GetImageStore(ModuleNameEnum moduleName, int moduleId, string imageType = "image")
        {
            return await _context.ImageStores
                .Where(x => !x.IsDeleted &&
                        x.ModuleId == moduleId &&
                        x.ModuleName == moduleName.ToString() && x.FileType == imageType)
                .ToListAsync();
        }

        public async Task<List<ImageStore>> GetImageStore(ModuleNameEnum? moduleName, List<int> moduleIds, string imageType = "image")
        {
            var data = await _context.ImageStores
               .Where(x => !x.IsDeleted &&
                      moduleIds.Contains(x.ModuleId) &&
                       ((x.ModuleName == moduleName.ToString() && moduleName != null) || moduleName == null) && (x.FileType == imageType || imageType == "file" || imageType == null))
               .ToListAsync();
            return data;
        }

        public async Task<List<ImageStore>> GetImageStore(ModuleNameEnum? moduleName, List<int> moduleIds, bool allImage)
        {
            
            var data = await _context.ImageStores
               .Where(x => !x.IsDeleted &&
                      moduleIds.Contains(x.ModuleId) &&
                       ((x.ModuleName == moduleName.ToString() && moduleName != null) || moduleName == null))
               .ToListAsync();
            return data;
        }

        public async Task<List<ImageStore>> GetImageStore(ModuleNameEnum moduleName, int moduleId, int sequenceNo, string imageType = "image")
        {
            return await _context.ImageStores
                .Where(x => !x.IsDeleted &&
                        x.ModuleId == moduleId &&
                        x.ModuleName == moduleName.ToString() &&
                        x.FileType == imageType)
                .ToListAsync();
        }

        public async Task<List<ImageStore>> GetImageStore(ModuleNameEnum moduleName, string fileType = "image")
        {
            return await _context.ImageStores
                .Where(x => !x.IsDeleted &&
                        x.ModuleName == moduleName.ToString() &&
                        x.FileType == fileType)
                .ToListAsync();
        }

        public async Task<List<ImageStore>> GetImageStore(Dictionary<ModuleNameEnum, List<int>> moduleNameAndIds, string imageType = "image")
        {
            var data= await _context.ImageStores
               .Where(x => !x.IsDeleted &&
                       x.FileType == imageType)
               .ToListAsync();
            var newData=new List<ImageStore>();
            foreach (var moduleNameAndId in moduleNameAndIds)
            {
                newData.AddRange(
                    data.
                    Where(x => x.ModuleName == moduleNameAndId.Key.ToString() && 
                                moduleNameAndId.Value.Contains(x.ModuleId)
                        )
                    .ToList()
                    );
            }
            return newData;
        }

        public async Task<List<ImageStoreWithName>> GetImageStore(ModuleNameEnum? moduleName,  int pageNo, int pageSize, bool allImage = false, string imageType = "360degreeimage")
        {
            var data=await _context.ImageStores
                .Where(x => !x.IsDeleted &&
                        x.ModuleName == moduleName.ToString() &&
                       (allImage || x.FileType == imageType))
                .OrderByDescending(x=>x.CreatedAt)
                .ToListAsync();
            var ids=new List<int>();
            var resp=data.Skip(pageSize*(pageNo-1)).Take(pageSize).ToList();
            var finalResp=new List<ImageStoreWithName>();
            if(moduleName==ModuleNameEnum.MasterAttraction)
            {
                ids=resp.Select(x=>x.ModuleId).ToList();
                var moduleData=await _context.MasterAttractions.Where(x=>ids.Contains(x.Id)).ToListAsync();
                var dic = moduleData.ToDictionary(x => x.Id, y => y);
                resp.ForEach(ele =>
                {
                    if(dic.ContainsKey(ele.ModuleId))
                    {
                        var item = _mapper.Map<ImageStoreWithName>(ele);
                        item.EnName = dic[ele.ModuleId].EnName;
                        item.HiName = dic[ele.ModuleId].HiName;
                        item.TaName = dic[ele.ModuleId].TaName;
                        item.TeName = dic[ele.ModuleId].TeName;
                        finalResp.Add(item);
                    }
                });
                return finalResp;
            }
            return default;
        }
    }
}
