using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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