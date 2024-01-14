using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApi;

public class Task
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Completed { get; set; }
    
    private DateTime _createdAt = DateTime.UtcNow;
    public DateTime CreatedAt
    {
        get => DateTime.SpecifyKind(_createdAt, DateTimeKind.Utc);
        set => _createdAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    private DateTime _updatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt
    {
        get => DateTime.SpecifyKind(_updatedAt, DateTimeKind.Utc);
        set => _updatedAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
}