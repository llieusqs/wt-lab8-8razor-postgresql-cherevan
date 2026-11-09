using System.ComponentModel.DataAnnotations;

namespace wt_lab8_8razor_postgresql_cherevan.Models;

public class TaskItem
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите название задачи")]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите проект")]
    public string Project { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите исполнителя")]
    public string Assignee { get; set; } = string.Empty;

    [Range(0.5, 1000, ErrorMessage = "Оценка должна быть от 0.5 до 1000 ч.")]
    public decimal EstimateHours { get; set; }

    public string Status { get; set; } = "To Do";

    // ДОБАВЛЯЕМ  ПОЛЕ
    public string Description { get; set; } = string.Empty;
}