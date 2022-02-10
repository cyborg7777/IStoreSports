using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore2.Models
{
    public class AppIndentityDbContext :IdentityDbContext<IdentityUser>
    {
        public AppIndentityDbContext(DbContextOptions<AppIndentityDbContext> options) : base(options) { }
    }
}
