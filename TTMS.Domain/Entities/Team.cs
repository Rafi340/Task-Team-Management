using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTMS.Domain.Entities
{
    public class Team : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
