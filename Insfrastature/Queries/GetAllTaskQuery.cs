using MediatR;

namespace MandrilAPI
{

    public class GetAllTaskQuery : IRequest<IEnumerable<TaskItemDTo>>;
}


