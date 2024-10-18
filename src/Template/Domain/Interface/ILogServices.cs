using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Interface
{
    public interface ILogServices
    {
        bool SaveLogsService(string messageLogs);
    }
}
