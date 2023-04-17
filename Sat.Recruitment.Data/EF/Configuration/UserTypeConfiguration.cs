using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sat.Recruitment.Common.Entities;

namespace Sat.Recruitment.Data.EF.Configuration
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(_ => _.UserTypeId);
            builder.Property(_ => _.UserTypeId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(240);

            builder.HasData(GetData());
        }

        private UserType[] GetData()
        {
            return new UserType[]
            {
                new UserType { UserTypeId = 1, Name = "Normal" },
                new UserType { UserTypeId = 2, Name = "SuperUser" },
                new UserType { UserTypeId = 3, Name = "Premium" },
            };

        }
    }
}
