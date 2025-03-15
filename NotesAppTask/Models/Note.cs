namespace NotesAppTask.Models;

public class Note
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = "Новая заметка";
    public string Content { get; set; } = "Это первая заметка!";
}