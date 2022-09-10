using Microsoft.EntityFrameworkCore;
using Productify.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productify.DAL.Context
{
    public class ProductifyDataContext : DbContext
    {
        public ProductifyDataContext(DbContextOptions<ProductifyDataContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
