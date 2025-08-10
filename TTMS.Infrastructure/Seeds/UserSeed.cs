using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Infrastructure.Identity;

namespace TTMS.Infrastructure.Seeds
{
    public static class UserSeed
    {
        public static ApplicationUser[] GetUsers()
        {
            var admin = new ApplicationUser
            {
                Id = new Guid("1A2073E8-D2CE-46B2-863B-3AAC8D29D163"),
                UserName = "admin@demo.com",
                NormalizedUserName = "ADMIN@DEMO.COM",
                Email = "admin@demo.com",
                NormalizedEmail = "ADMIN@DEMO.COM",
                EmailConfirmed = true,
                FullName = "Admin",
                ConcurrencyStamp = "5b20a20f-40a0-4f82-bbf4-8c6995d4091a",
                SecurityStamp = "ee4bfc33-f7b1-4a2f-9a97-cc0c923b0493",
                PasswordHash = "AQAAAAIAAYagAAAAEHqH5bT8EJGLxj1qV6FmrS+bt3Is6a1Qn2G7UnFg6px0+ML6pSHn5vAWwUguo9w1BA==" 
            };

            var manager = new ApplicationUser
            {
                Id = new Guid("A036CCD4-08FC-4FE6-B217-ADC8F84386FC"),
                UserName = "manager@demo.com",
                NormalizedUserName = "MANAGER@DEMO.COM",
                Email = "manager@demo.com",
                NormalizedEmail = "MANAGER@DEMO.COM",
                EmailConfirmed = true,
                FullName = "Manager",
                ConcurrencyStamp = "35b88d79-5b64-4f9c-a6b5-8d9bbba5bc1b",
                SecurityStamp = "a27b30aa-6f6f-4fc0-bf8c-38cc9e7f2835",
                PasswordHash = "AQAAAAIAAYagAAAAEH2W9Fh6s0vA7fZTFoR6oUSK7JxjX9Ybm46+dOqCjzK7Jrrshx6i9rB3JpWw92yq9Q==" 
            };

            var employee = new ApplicationUser
            {
                Id = new Guid("1E945B04-5CD5-419E-AE40-5185EB5A94D5"),
                UserName = "employee@demo.com",
                NormalizedUserName = "EMPLOYEE@DEMO.COM",
                Email = "employee@demo.com",
                NormalizedEmail = "EMPLOYEE@DEMO.COM",
                EmailConfirmed = true,
                FullName = "Employee",
                ConcurrencyStamp = "1b498b47-6d94-44f0-8f89-4b1840d26034",
                SecurityStamp = "6c9f38b3-a1b4-4a0d-b5f6-0ee6f6a42f0a",
                PasswordHash = "AQAAAAIAAYagAAAAEHv5mJXYb0S0XwnnO9Tnuf6SVTKRZy2U6n7cLupIYfH4UJ8uO9Y/6xq6W+3AxnZpTg==" 
            };

            return new ApplicationUser[] { admin, manager ,employee };
        }
    }
}
