using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_cherevan.Data;
using wt_lab8_8razor_postgresql_cherevan.Models;

namespace wt_lab8_8razor_postgresql_cherevan.Pages.Tasks;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TaskItem Task { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var task = await _context.Tasks.FirstOrDefaultAsync(m => m.Id == id);
        if (task == null) return NotFound();

        Task = task;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        // Обновляем запись в базе данных
        _context.Attach(Task).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}