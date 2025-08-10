using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Domain.Entities;

namespace TTMS.Domain.Contract.Request
{
    public class CreateTaskRequest
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid? AssignedToUserId { get; set; }
    }
}
