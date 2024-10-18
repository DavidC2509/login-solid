using Core.CommandAndQueryHandler.Repository;
using Core.Domain;
using Core.Domain.Domain;
using Core.Domain.Repository;
using Template.Command.Database;
namespace Template.Command
{
    public class EfRepository<T> : BaseRepository<T, DataBaseContext>, IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        public EfRepository(DataBaseContext context) : base(context) { }
    }
}
