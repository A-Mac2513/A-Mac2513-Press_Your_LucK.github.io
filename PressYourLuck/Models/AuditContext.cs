using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Models
{
    public class AuditContext : DbContext
    {
        public AuditContext(DbContextOptions options)
            : base(options) { }

        public DbSet<AuditType> AuditTypes { get; set; }

        public DbSet<Audit> Audits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditType>().HasData(
                new AuditType()
                {
                    AuditTypeId = "ci",
                    Name = "Cash In"
                },
                new AuditType()
                {
                    AuditTypeId = "co",
                    Name = "Cash Out"
                },
                new AuditType()
                {
                    AuditTypeId = "w",
                    Name = "Win"
                },
                new AuditType()
                {
                    AuditTypeId = "l",
                    Name = "Lose"
                });
        }
    }
}
