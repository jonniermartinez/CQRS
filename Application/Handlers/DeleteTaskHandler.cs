using MandrilAPI.infrastature;
using MediatR;

namespace MandrilAPI;

public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
{
    private readonly applicationDbContext _dbContext;

    public DeleteTaskHandler(applicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var TaskItem = await _dbContext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);

        if (TaskItem == null)
        {
            return false;
        }

        _dbContext.TaskItems.Remove(TaskItem);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }

}
