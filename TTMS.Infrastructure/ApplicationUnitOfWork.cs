using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Application;

namespace TTMS.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork , IApplicationUnitOfWork
    {
        public ApplicationUnitOfWork(ApplicationDbContext dbContext
            ) : base(dbContext)
        {
        }
    }

}
