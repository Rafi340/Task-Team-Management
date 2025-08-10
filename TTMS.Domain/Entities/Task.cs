using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTMS.Domain.Entities
{
    public class Tasks : BaseModel, IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid? AssignedToUserId { get; set; }
        public Guid? TeamId { get; set; }
        public Team? Team { get; set; }

    }
}
