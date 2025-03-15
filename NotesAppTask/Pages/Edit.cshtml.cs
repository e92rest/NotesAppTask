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

    [BindProperty]
    public Note Note { get; set; } = default!;

    public IActionResult OnGet(Guid id)
    {
        var note = _service.GetById(id);
        if (note == null) return NotFound();

        Note = note;
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        _service.Update(Note);
        return RedirectToPage("Index");
    }
}