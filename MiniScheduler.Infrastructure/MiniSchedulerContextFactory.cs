using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace MiniScheduler.Infrastructure
{
    public class MiniSchedulerContextFactory : IDesignTimeDbContextFactory<MiniSchedulerContext>
    {
        public MiniSchedulerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MiniSchedulerContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Directory.GetCurrentDirectory() + "/../MiniScheduler.Api/appsettings.json")
                .Build();

            optionsBuilder
                 .UseSqlServer(configuration.GetConnectionString("MiniSchedulerDb"));

            return new MiniSchedulerContext(optionsBuilder.Options);
        }
    }
}
