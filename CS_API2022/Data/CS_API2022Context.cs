using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CS_API2022.Models;

namespace CS_API2022.Data
{
    public class CS_API2022Context : DbContext
    {
        public CS_API2022Context (DbContextOptions<CS_API2022Context> options)
            : base(options)
        {
        }

        public DbSet<CS_API2022.Models.Projects> Projects { get; set; } = default!;

        public DbSet<CS_API2022.Models.Users> Users { get; set; }
    }
}
