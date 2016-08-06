using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace Data.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        MoviesDBEntities Init();
    }
}
