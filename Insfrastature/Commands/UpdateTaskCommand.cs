using MediatR;

namespace MandrilAPI
{
    public record UpdateTaskCommand(int Id, string Title, string Description, bool IsCompleted) : IRequest<TaskItemDTo>;

}