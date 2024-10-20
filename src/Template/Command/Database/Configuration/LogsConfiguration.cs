using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.LogsAggregate;

namespace Template.Command.Database.Configuration
{
    public class LogsConfiguration : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.ToTable("Logs");

            // Configure the Id property to use the database default value for new entities
            builder.Property(e => e.Id)
                   .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}