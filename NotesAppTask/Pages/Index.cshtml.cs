using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesAppTask.Data;
using NotesAppTask.Models;

public class IndexModel : PageModel
{
    private readonly NotesService _service; // Для работы с заметками
    
    // Конструктор с зависимостями
    public IndexModel(NotesService service)
    {
        _service = service;
    }

    public List<Note> Notes { get; private set; } = [];

    // GET-запрос на загрузку всех заметок
    public void OnGet()
    {
        Notes = _service.GetAll();
    }

    // Обрабатываем удаление заметок по id
    public IActionResult OnGetDelete(Guid id)
    {
        _service.Delete(id);
        return RedirectToPage();
    }
}