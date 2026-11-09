using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_cherevan.Data;
using wt_lab8_8razor_postgresql_cherevan.Models;

namespace wt_lab8_8razor_postgresql_cherevan.Pages.Tasks;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<TaskItem> TaskItem { get; set; } = default!;

    // Свойство для хранения текста поиска
    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public async Task OnGetAsync()
    {
        // Базовый запрос к базе данных
        var query = _context.Tasks.AsQueryable();

        // Если введен текст поиска, фильтруем по названию
        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(t => t.Title.Contains(Search));
        }

        // Получаем отфильтрованные данные из PostgreSQL
        TaskItem = await query.ToListAsync();
    }

    // Обработчик для удаления задачи (POST)
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var taskToRemove = await _context.Tasks.FindAsync(id);
        if (taskToRemove != null)
        {
            _context.Tasks.Remove(taskToRemove);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage("./Index");
    }
}