using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.Data.SQLServer
{
    public class WhoWorksContextFactory : IDesignTimeDbContextFactory<WhoWorksDbContext>
    {
        public WhoWorksDbContext CreateDbContext(string[] args)
        {


            //get access to record in settings file
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(
                Path.Combine(Directory.GetCurrentDirectory(), "Settings", "appSettings.json"));
          
            var configurationRoot = configurationBuilder.Build();
            string connectionString = configurationRoot.GetConnectionString("WhoWorksDatabase");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder();

            dbContextOptionsBuilder.UseSqlServer(connectionString, 
                b => b.MigrationsAssembly("WhoWorks.Data.Migrations"));

            return new WhoWorksDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
