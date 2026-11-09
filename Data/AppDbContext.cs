using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_cherevan.Models;

namespace wt_lab8_8razor_postgresql_cherevan.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Используем ваше название модели TaskItem
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}