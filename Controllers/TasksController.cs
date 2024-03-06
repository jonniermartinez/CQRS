using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<TaskItemDTo>> GetAll()
        {
            return await _mediator.Send(new GetAllTaskQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDTo>> GetById(int id)
        {
            var query = new GetTaskByIdQuery(id);
            var taskItem = await _mediator.Send(query);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        [HttpPost]
        public async Task<ActionResult<TaskItemDTo>> Create(CreateTaskCommand command)
        {
            var taskItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = taskItem.Id }, taskItem);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TaskItemDTo>> Update(int id, UpdateTaskCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var taskItem = await _mediator.Send(command);
            if (taskItem == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskItemDTo>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteTaskCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}

