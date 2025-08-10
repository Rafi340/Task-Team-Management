using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Domain.Entities;

namespace TTMS.Application.Validator
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x=> x.Name).NotEmpty();
        }
    }
}
