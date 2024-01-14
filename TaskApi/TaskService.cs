using Microsoft.EntityFrameworkCore;

namespace TaskApi;

public class TaskService
{
    private readonly TaskDbContext _context;

    public TaskService(TaskDbContext context)
    {
        _context = context;
        if (_context.Database.EnsureCreated()) return;
        Console.WriteLine("DB does not exist, migrating...");
        _context.Database.Migrate();
    }

    public IEnumerable<Task> Get()
    {
        return _context.Tasks.ToList();
    }

    public Task Get(int id)
    {
        var task = _context.Tasks.Find(id);

        if (task == null)
        {
            throw new KeyNotFoundException($"Task {id} not found");
        }

        return task;
    }

    public Task Post(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return task;
    }

    public Task Put(int id, Task updatedTask)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            throw new KeyNotFoundException($"Task {id} not found");
        }

        task.Name = updatedTask.Name;
        task.Description = updatedTask.Description;
        task.Completed = updatedTask.Completed;
        task.UpdatedAt = DateTime.Now;
        _context.SaveChanges();

        return task;
    }

    public string Delete(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            throw new KeyNotFoundException($"Task {id} not found");
        }

        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return $"Task {id} deleted";
    }
}