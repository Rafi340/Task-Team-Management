using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTMS.Application.Exceptions
{
    public class DuplicateTeamNameExceptions : Exception
    {
        public DuplicateTeamNameExceptions() : base("Teams Name Can't be Duplicate") 
        { }
    }
}
