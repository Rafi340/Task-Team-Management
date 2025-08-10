using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Domain.Contract.Request;
using TTMS.Domain.Entities;

namespace TTMS.Application.Features.Teams.Commands
{
    public class TeamAddCommand : IRequest<Team>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<CreateTaskRequest>? Tasks { get; set; } = new();
    }
}
