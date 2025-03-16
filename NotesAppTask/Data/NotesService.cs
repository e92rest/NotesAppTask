using NotesAppTask.Models;
using System.Text.Json;

namespace NotesAppTask.Data;

// Класс для добавления, изменения, сохранения и удаления заметок
public class NotesService
{
    private const string FilePath = "notes.json"; // В notes.json будут хранится заметки
    private List<Note> _notes; // Внутренний список заметок
    
    /*
     Конструктор для заметок, сначала проверяем есть ли файл с заметками, 
     если есть то читаем и десереализуем данные.
     Если файла нету, тогда создаем список с новой пустой заметкой и сохраняем.
     */
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

    public List<Note> GetAll() => _notes; // Получаем все заметки
    public Note? GetById(Guid id) => _notes.FirstOrDefault(n => n.Id == id); // Получаем заметку по идентификатору (ID)

    // Добавляем (создаем) заметку в список, затем сохраняем
    public void Add(Note note)
    {
        _notes.Add(note);
        SaveChanges();
    }

    /*
     Изменяем существующую заметку, сначала по id находим, если нашли,
     тогда изменяем содержимое и сохраняем 
     */
    public void Update(Note note)
    {
        var index = _notes.FindIndex(n => n.Id == note.Id);
        if (index != -1)
        {
            _notes[index] = note;
            SaveChanges();
        }
    }

    // Удаляем заметки по id, затем сохраняем изменения
    public void Delete(Guid id)
    {
        _notes.RemoveAll(n => n.Id == id);
        SaveChanges();
    }

    /*
     Сохраняем текущий список заметок в json файл
     (сериализируем список в формат json с отступами), 
     затем записываем в файл 
     */
    private void SaveChanges()
    {
        var json = JsonSerializer.Serialize(_notes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
}
