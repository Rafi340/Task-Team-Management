using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Domain.Entities;

namespace TTMS.Domain.Repositories
{
    public interface ITeamRepository : IRepository<Team, Guid>
    {
        bool IsTeamNameDuplicate(string name, Guid? id = null);
    }
}
