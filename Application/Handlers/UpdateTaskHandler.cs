using MandrilAPI.infrastature;
using MediatR;

namespace MandrilAPI;

public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskItemDTo>
{

    private readonly applicationDbContext _dbContext;

    public UpdateTaskHandler(applicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<TaskItemDTo> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskItem = await _dbContext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);

        if (taskItem == null)
        {
            return null;
        }
        taskItem.Title = request.Title;
        taskItem.Description = request.Description;
        taskItem.IsCompleted = request.IsCompleted;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new TaskItemDTo
        {
            Id = taskItem.Id,
            Title = taskItem.Title,
            Description = taskItem.Description,
            IsCompleted = taskItem.IsCompleted
        };
    }
}
