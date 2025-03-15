using NotesAppTask.Models;
using System.Text.Json;

namespace NotesAppTask.Data;

public class NotesService
{
    private const string FilePath = "notes.json";
    private List<Note> _notes;

    public NotesService()
    {
        if (File.Exists(FilePath))
        {
            var json = File.ReadAllText(FilePath);
            _notes = JsonSerializer.Deserialize<List<Note>>(json) ?? new List<Note>();
        }
        else
        {
            _notes = new List<Note> { new Note() };
            SaveChanges();
        }
    }

    public List<Note> GetAll() => _notes;

    public Note? GetById(Guid id) => _notes.FirstOrDefault(n => n.Id == id);

    public void Add(Note note)
    {
        _notes.Add(note);
        SaveChanges();
    }

    public void Update(Note note)
    {
        var index = _notes.FindIndex(n => n.Id == note.Id);
        if (index != -1)
        {
            _notes[index] = note;
            SaveChanges();
        }
    }

    public void Delete(Guid id)
    {
        _notes.RemoveAll(n => n.Id == id);
        SaveChanges();
    }

    private void SaveChanges()
    {
        var json = JsonSerializer.Serialize(_notes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
}
