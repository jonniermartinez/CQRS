using MandrilAPI.infrastature;
using MediatR;

namespace MandrilAPI;

public class GetTaskTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDTo>
{
    private readonly applicationDbContext _dbContext;

    public GetTaskTaskByIdHandler(applicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<TaskItemDTo> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _dbContext.TaskItems.FindAsync(new Object[] { request.Id }, cancellationToken);

        if (task == null)
        {
            return null;
        }
        return new TaskItemDTo
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted
        };

    }
}
