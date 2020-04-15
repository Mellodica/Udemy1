using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Udemy1.Models;

    public class TudoContext : DbContext
    {
        public TudoContext (DbContextOptions<TudoContext> options)
            : base(options)
        {
        }

        public DbSet<Udemy1.Models.Departamento> Departamento { get; set; }
    }
