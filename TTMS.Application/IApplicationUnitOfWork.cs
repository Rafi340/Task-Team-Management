using TTMS.Domain;
using TTMS.Domain.Repositories;

namespace TTMS.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        public ITeamRepository TeamRepository { get; }
    }
}
