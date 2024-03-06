using MediatR;

namespace MandrilAPI
{
    public record GetTaskByIdQuery(int Id) : IRequest<TaskItemDTo>;

}

