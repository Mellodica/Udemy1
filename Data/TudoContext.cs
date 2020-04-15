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

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<VendaGravada> VendaGravadas { get; set; }
}
