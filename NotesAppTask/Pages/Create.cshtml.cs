using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesAppTask.Data;
using NotesAppTask.Models;

public class CreateModel : PageModel
{
    private readonly NotesService _service;
    public CreateModel(NotesService service)
    {
        _service = service;
    }
    
    // Связываем свойство Note с формой
    [BindProperty]
    public Note Note { get; set; } = new();

    /*
     * POST:
     * 1. Проверяем корректность содержимого
     * 2. Затем добавляем заметку и возвращаемся к списку (главную страницу)
     */
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        _service.Add(Note);
        return RedirectToPage("Index");
    }
}