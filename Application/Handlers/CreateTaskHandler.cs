using MandrilAPI.infrastature;
using MediatR;

namespace MandrilAPI;

public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskItemDTo>
{
    private readonly applicationDbContext _dbContext;

    public CreateTaskHandler(applicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TaskItemDTo> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskItem = new TaskItem
        {
            Title = request.Title,
            Description = request.Description
        };

        _dbContext.TaskItems.Add(taskItem);
        // No entiendo porque un cancellation
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
