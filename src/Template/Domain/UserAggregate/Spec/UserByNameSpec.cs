using Ardalis.Specification;

namespace Template.Domain.UserAggregate.Spec
{
    public class UserByNameSpec : Specification<User>
    {
        public UserByNameSpec(string name)
        {
            Query
            .Where(c => c.Name.Equals(name));
        }
    }
}