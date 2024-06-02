using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AyodhyaYatra.API.Repository
{
    public class MobileLogicRespository : IMobileLogicRespository
    {
        private readonly AyodhyaYatraContext _context;
        public MobileLogicRespository(AyodhyaYatraContext context)
        {
            _context = context;
        }
        public async Task<List<MasterAttraction>> GetAttractionList()
        {
            return await _context.MasterAttractions
                .Include(x=>x.MasterAttractionType)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.EnName).ToListAsync();
        }
    }
}
