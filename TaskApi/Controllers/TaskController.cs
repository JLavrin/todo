using Microsoft.AspNetCore.Mvc;

namespace TaskApi.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_taskService.Get());
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        return Ok(_taskService.Get(id));
    }

    [HttpPost]
    public IActionResult Post(Task newTask)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_taskService.Post(newTask));
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, Task updatedTask)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_taskService.Put(id, updatedTask));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return Ok(_taskService.Delete(id));
    }
}
