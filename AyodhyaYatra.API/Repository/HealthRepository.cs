using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace SalehGarib.API.Repositories
{
    public class HealthRepository : IHealthRepository
    {
        private readonly AyodhyaYatraContext _context;
        public HealthRepository(AyodhyaYatraContext context)
        {
            _context = context;
        }
        public string GetDatabaseName()
        {
            return _context.Database.GetDbConnection().Database;
        }
    }
}
