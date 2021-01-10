using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Morar_Antoniu_Lab8.Models;

namespace Morar_Antoniu_Lab8.Data
{
    public class Morar_Antoniu_Lab8Context : DbContext
    {
        public Morar_Antoniu_Lab8Context (DbContextOptions<Morar_Antoniu_Lab8Context> options)
            : base(options)
        {
        }

        public DbSet<Morar_Antoniu_Lab8.Models.Joc> Joc { get; set; }

        public DbSet<Morar_Antoniu_Lab8.Models.Publisher> Publisher { get; set; }

        public DbSet<Morar_Antoniu_Lab8.Models.Category> Category { get; set; }
    }
}
