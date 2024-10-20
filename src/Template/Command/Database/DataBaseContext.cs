
using Core.Cqrs.CommandAndQueryHandler;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace Template.Command.Database
{
    public class DataBaseContext : BaseDbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options, IMediator mediator)
            : base(options, mediator)
        {
        }

        public override string Owner => "template";
        public override string TablePrefix => "template";


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnPreModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
