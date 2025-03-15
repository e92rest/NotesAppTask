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

    [BindProperty]
    public Note Note { get; set; } = new();

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        _service.Add(Note);
        return RedirectToPage("Index");
    }
}