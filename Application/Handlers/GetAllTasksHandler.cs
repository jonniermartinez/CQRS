using MandrilAPI.infrastature;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI;

public class GetAllTasksHandler : IRequestHandler<GetAllTaskQuery, IEnumerable<TaskItemDTo>>
{

    private readonly applicationDbContext _dbContext;

    public GetAllTasksHandler(applicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TaskItemDTo>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _dbContext.TaskItems.ToListAsync(cancellationToken);

        return tasks.Select(task => new TaskItemDTo
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted
        });
    }
}
