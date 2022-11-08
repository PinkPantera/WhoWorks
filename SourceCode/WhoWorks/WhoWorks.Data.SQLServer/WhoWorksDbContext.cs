using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Core;
using WhoWorks.Data.SQLServer.Configurations;
using WhoWorks.Domain.Models;

namespace WhoWorks.Data.SQLServer
{
    public class WhoWorksDbContext : DbContext, IUnitOfWork
    {
        public WhoWorksDbContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfigaration());
            modelBuilder.ApplyConfiguration(new PhotoEntityTypeConfigaration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
