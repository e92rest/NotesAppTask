namespace NotesAppTask.Models;

public class Note
{
    public Guid Id { get; set; } = Guid.NewGuid(); // Идентификатор заметки
    public string Title { get; set; } = "Новая заметка"; // Заголовок
    public string Content { get; set; } = "Это новая заметка"; // Содержимое
}