using Microsoft.EntityFrameworkCore;
using MyBlazorHybridApp.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlazorHybridApp.Shared.Data
{
    public class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PizzaSpecial> Specials { get; set; }
    }
}
