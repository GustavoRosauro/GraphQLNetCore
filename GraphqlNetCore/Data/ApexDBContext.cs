using GraphqlNetCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlNetCore.Data
{
    public class ApexDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public ApexDBContext(DbContextOptions<ApexDBContext> options)
            : base(options) { }
    }
}
