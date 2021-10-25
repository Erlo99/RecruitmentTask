using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecruitmentTask.Models;
using RecruitmentTask.Models.Foreign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask
{
    public class DataBaseContext : DbContext
    {
        private readonly ILogger _logger;
        public DataBaseContext(ILogger logger)
        {
            _logger = logger;
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Cargo> Cargo { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);



            foreach (var entityEntry in entries)
            {

                if (entityEntry.State == EntityState.Added)
                {
                    ((Auditable)entityEntry.Entity).ModifiedAt = DateTime.UtcNow;
                    ((Auditable)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    _logger.LogInformation($"User added: " + entityEntry.OriginalValues.ToObject().ToString());
                }
                else if (entityEntry.State == EntityState.Deleted)
                {
                    _logger.LogInformation($"User deleted: " + entityEntry.OriginalValues.ToObject().ToString());
                }
                else
                {
                    ((Auditable)entityEntry.Entity).ModifiedAt = DateTime.UtcNow;
                    _logger.LogInformation($"User Modified: " + entityEntry.OriginalValues.ToObject().ToString());
                }

            }

            return base.SaveChanges();
        }
    }
}
