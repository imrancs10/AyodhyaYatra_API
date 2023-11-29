using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaashiYatra.API.Repository.IRepository
{
    public interface IHealthRepository
    {
        string GetDatabaseName();
    }
}
