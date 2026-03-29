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
    [HttpGet] // Кнопка "Получить список"
    public IActionResult GetGoals()
    {
        var allGoals = _context.Goals.ToList(); // Забираем всё из SQL
        return Ok(allGoals); // Выдаем в браузер
    }
    [HttpDelete("{id}")] // Кнопка "Удалить по номеру"
    public IActionResult DeleteGoal(int id)
    {
        var target = _context.Goals.Find(id); // Ищем цель по Id
        if (target == null) return NotFound("Такой цели нет");

        _context.Goals.Remove(target); // Удаляем из списка
        _context.SaveChanges();      // Сохраняем в SQL
        return Ok($"Цель номер {id} удалена");
    }

}
