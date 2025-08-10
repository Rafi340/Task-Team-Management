using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Application;
using TTMS.Domain.Repositories;

namespace TTMS.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork , IApplicationUnitOfWork
    {
        public ApplicationUnitOfWork(ApplicationDbContext dbContext,
            ITeamRepository teamRepository
            ) : base(dbContext)
        {
            TeamRepository = teamRepository;
        }

        public ITeamRepository TeamRepository { get; private set; }

    }

}
