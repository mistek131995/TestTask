using MediatR;

namespace TestTask.Query.Service.GetProject
{
    public class Query : IRequest<ViewModel>
    {
        public Guid Guid { get; set; }
    }
}
