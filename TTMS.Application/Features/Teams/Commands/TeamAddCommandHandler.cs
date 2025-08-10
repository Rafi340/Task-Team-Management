using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Application.Exceptions;
using TTMS.Domain.Entities;

namespace TTMS.Application.Features.Teams.Commands
{
    public class TeamAddCommandHandler(IApplicationUnitOfWork applicationUnitOfWork, 
        IMapper mapper,
        IValidator<Team> teamValidator) : IRequestHandler<TeamAddCommand, Team>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IApplicationUnitOfWork _applicationUnitOfWork = applicationUnitOfWork;
        private readonly IValidator<Team> _teamValidator = teamValidator;
        public async Task<Team> Handle(TeamAddCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Team>(request);
            if (!_applicationUnitOfWork.TeamRepository.IsTeamNameDuplicate(map.Name))
            {
                await _teamValidator.ValidateAndThrowAsync(map);
                await _applicationUnitOfWork.TeamRepository.AddAsync(map);
                await _applicationUnitOfWork.SaveAsync();
                return map;
            }
            else
                throw new DuplicateTeamNameExceptions();

        }
    }
}
