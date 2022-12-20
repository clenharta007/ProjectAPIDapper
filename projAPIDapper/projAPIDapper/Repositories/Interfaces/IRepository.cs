using projAPIDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projAPIDapper.Repositories.Interfaces
{
    public interface IRepository
    {
        IEnumerable<PresenceBook> Get();
        IEnumerable<PresenceBook> Get(int Id);
        int Insert(PresenceBook presenceBook);
        int Update(PresenceBook presenceBook);
        int Delete(int Id);

    }
}
