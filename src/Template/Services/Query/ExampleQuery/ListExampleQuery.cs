using MediatR;
using Template.Services.Models;

namespace Template.Services.Query.ExampleQuery
{
    public class ListExampleQuery : IRequest<IEnumerable<ExampleModels>>
    {
    }
}
