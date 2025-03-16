using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesAppTask.Data;
using NotesAppTask.Models;

public class EditModel : PageModel
{
    private readonly NotesService _service;
    public EditModel(NotesService service)
    {
        _service = service;
    }
    // Привязка свойства Note к форме на странице
    [BindProperty]
    public Note Note { get; set; } = default!;

    /*
     * GET:
     * 1. Заметка по id
     * 2. Если не найдена - возвращаем 404
     * 3. Устанавливаем найденную заметку в модели и возвращаем страницу
     */
    public IActionResult OnGet(Guid id)
    {
        var note = _service.GetById(id);
        if (note == null) return NotFound();

        Note = note;
        return Page();
    }

    
    /*
     * POST:
     * 1. Проверяем форму на корректность
     * 2. Обновляем заметку
     * 3. Возвращаемся к списку заметок (на главную страницу)
     */
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        _service.Update(Note);
        return RedirectToPage("Index");
    }
}