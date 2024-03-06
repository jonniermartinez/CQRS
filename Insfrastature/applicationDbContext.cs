using Microsoft.EntityFrameworkCore;


namespace MandrilAPI.infrastature
{
    public class applicationDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }

        public applicationDbContext(DbContextOptions<applicationDbContext> options)
            : base(options)
        {

        }

    }

}

