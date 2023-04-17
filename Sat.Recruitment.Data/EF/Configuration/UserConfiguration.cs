using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sat.Recruitment.Common.Entities;

namespace Sat.Recruitment.Data.EF.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_ => _.UserId);
            builder.Property(_ => _.UserId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(_ => _.Email).IsRequired().HasMaxLength(255);
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(255);
            builder.Property(_ => _.Phone).IsRequired().HasMaxLength(255);
            builder.Property(_ => _.UserTypeId).IsRequired();
            builder.Property(_ => _.Address).IsRequired().HasMaxLength(1200);
            builder.Property(_ => _.Money).IsRequired(false);

            builder.HasOne(u => u.UserType)
                    .WithMany(ut => ut.Users)
                    .HasForeignKey(u => u.UserTypeId);
        }
    }
}
