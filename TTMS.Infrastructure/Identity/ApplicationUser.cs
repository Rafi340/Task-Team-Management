using Microsoft.AspNetCore.Identity;
using System;

namespace TTMS.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }

    }
}
