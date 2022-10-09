using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RichestHumansAlive.Models;

    public class RichestHumansAliveContext : DbContext
    {
        public RichestHumansAliveContext (DbContextOptions<RichestHumansAliveContext> options)
            : base(options)
        {
        }

        public DbSet<RichestHumansAlive.Models.RichHuman> RichHuman { get; set; } = default!;
    }
