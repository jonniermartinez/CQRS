using MediatR;

namespace MandrilAPI
{
    public record CreateTaskCommand(string Title, string Description) : IRequest<TaskItemDTo>;
}