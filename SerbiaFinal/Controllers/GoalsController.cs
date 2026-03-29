using Microsoft.AspNetCore.Mvc;
using SerbiaFinal;

[ApiController]
[Route("api/[controller]")]
public class GoalsController : ControllerBase
{
    private readonly AppDbContext _context;

    public GoalsController(AppDbContext context)
    {
        _context = context; // Получаем наш "Мост"
    }

    [HttpPost] // Кнопка "Создать"
    public IActionResult CreateGoal(string text)
    {
        var newGoal = new Goals { Description = text };
        _context.Goals.Add(newGoal); // Кладем в корзину
        _context.SaveChanges();     // Записываем в реальную базу
        return Ok("Цель сохранена в SQL!");
    }
}
