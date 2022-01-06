using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTC13357.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GTC13357.Data
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public
            AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }

       

    }
}