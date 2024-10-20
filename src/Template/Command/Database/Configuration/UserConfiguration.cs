using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.UserAggregate;

namespace Template.Command.Database.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("UserLogin");

            // Configure the Id property to use the database default value for new entities
            builder.Property(e => e.Id)
                   .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}