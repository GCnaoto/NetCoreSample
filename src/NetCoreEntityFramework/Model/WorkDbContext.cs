using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;

namespace NetCoreEntityFramework.Model
{
    public class WorkDbContext : DbContext
    {
        private ILoggerFactory _loggerfact;

        public WorkDbContext(DbContextOptions<LogDbContext> options, ILoggerFactory logger)
        {
            //_logger = logger.CreateLogger("TodoApi.Controllers.TodoController");
            //Database.EnsureCreated();
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Addresses> Addresses { get; set; }

        public override int SaveChanges()
        {
            var now = DateTime.Now;
            SetCreateDateTime(now);
            return base.SaveChanges();
        }

        private void SetCreateDateTime(DateTime now)
        {
            var entities = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.CurrentValues.Properties.Any(x => x.Name.Contains("UpDate")))
                .Select(e => e.Entity);

            foreach (dynamic entity in entities)
            {
                entity.UpDate = now;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefoltDb"));
        }
    }
}