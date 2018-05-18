using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreEntityFramework.Model
{
    public class LogDbContext : DbContext
    {
        private ILoggerFactory _loggerfact;

        public LogDbContext(DbContextOptions<LogDbContext> options, ILoggerFactory logger)
        {
            //_logger = logger.CreateLogger("TodoApi.Controllers.TodoController");
            //Database.EnsureCreated();
        }

        public DbSet<Logs> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=logdb1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
            //optionsBuilder.UseSqlite(@"Data Source='hello.db'");
        }
    }
}