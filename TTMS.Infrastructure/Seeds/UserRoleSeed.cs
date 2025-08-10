using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Infrastructure.Identity;

namespace TTMS.Infrastructure.Seeds
{
    public static class UserRoleSeed
    {
        public static ApplicationUserRole[] GetUserRoles()
        {
            return new[]
            {
            // Admin User
            new ApplicationUserRole
            {
                UserId = new Guid("1A2073E8-D2CE-46B2-863B-3AAC8D29D163"),
                RoleId = new Guid("5E76C76D-4CF6-4784-8796-FD9F5C8CF29D")
            },
            // Manager User
            new ApplicationUserRole
            {
                UserId = new Guid("A036CCD4-08FC-4FE6-B217-ADC8F84386FC"),
                RoleId = new Guid("23FE4E81-5015-42A0-8D76-D1F08C6B227A")
            },
            // Employee User
            new ApplicationUserRole
            {
                UserId = new Guid("1E945B04-5CD5-419E-AE40-5185EB5A94D5"),
                RoleId = new Guid("B7A80D7E-24D8-4CC3-8981-EE4E1B5B1B3A")
            }
        };
        }
    }
}
