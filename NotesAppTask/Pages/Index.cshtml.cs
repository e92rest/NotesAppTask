using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesAppTask.Data;
using NotesAppTask.Models;

public class IndexModel : PageModel
{
    private readonly NotesService _service;

    public IndexModel(NotesService service)
    {
        _service = service;
    }

    public List<Note> Notes { get; private set; } = [];

    public void OnGet()
    {
        Notes = _service.GetAll();
    }

    public IActionResult OnGetDelete(Guid id)
    {
        _service.Delete(id);
        return RedirectToPage();
    }
}