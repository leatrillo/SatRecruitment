using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Common.Entities;
using Sat.Recruitment.Data.EF.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ////throw new NotSupportedException();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
        }

        public List<string> GetKey<T>() where T : class
        {
            var keyNames = this.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
                .Select(x => x.Name);

            return keyNames.ToList();
        }
    }
    
}