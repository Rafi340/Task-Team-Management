using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Domain.Entities;
using TTMS.Domain.Repositories;

namespace TTMS.Infrastructure.Repositories
{
    public class TeamRepository : Repository<Team, Guid>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool IsTeamNameDuplicate(string name, Guid? id = null)
        {
            if (id.HasValue)
                return GetCount(x => x.Id != id.Value && x.Name == name) > 0;
            else
                return GetCount(x => x.Name == name) > 0;
        }
    }
}
