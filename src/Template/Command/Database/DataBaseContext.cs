
using Core.CommandAndQueryHandler;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Template.Domain.ExampleAggregate;

namespace Template.Command.Database
{
    public class DataBaseContext : BaseDbContext
    {

        public DataBaseContext(IMediator mediator) : base(mediator)
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options, IMediator mediator)
            : base(options, mediator)
        {
        }

        public override string Owner => "template";
        public override string TablePrefix => "template";

        /// <summary>
        /// Todo los registros de las entidades se hacen aqui con sus configuraciones
        /// </summary>
        /// <param name="modelBuilder">Constructor de modelos</param>
        protected override void OnPreModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Example> Examples => Set<Example>();


    }
}
