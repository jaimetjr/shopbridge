using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DataContext : DbContext
    {
        protected string ConnectionString;

        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext(string cs)
        {
            ConnectionString = cs;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                if (!String.IsNullOrEmpty(ConnectionString))
                {
                    optionsBuilder.UseSqlServer(ConnectionString,
                    (obj) =>
                    {
                        obj.EnableRetryOnFailure(10);
                        obj.CommandTimeout(1500000);

                    });
                }



                if (Environment.GetEnvironmentVariable("ENVIRONMENT") == "Development" || Environment.GetEnvironmentVariable("DEBUGMODE") == "TRUE")
                {
                    //optionsBuilder.UseLoggerFactory(LF.logger);
                    optionsBuilder.EnableSensitiveDataLogging();
                    optionsBuilder.EnableDetailedErrors();
                    //optionsBuilder.AddInterceptors(new EFTransactionInterceptor());
                }

                //optionsBuilder.UseLazyLoadingProxies(true);
                base.OnConfiguring(optionsBuilder);


            }
            catch (Exception) { }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
