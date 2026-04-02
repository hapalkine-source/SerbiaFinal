using Microsoft.AspNetCore.Mvc;
using SerbiaFinal;
namespace SerbiaFinal.DTOs;
using SerbiaFinal.DTOs;
using static SerbiaFinal.Goals;

[ApiController]
[Route("api/[controller]")]
public class GoalsController : ControllerBase
{
    private readonly AppDbContext _context;

    public GoalsController(AppDbContext context)
    {
        _context = context; // Получаем наш "Мост"
    }

    [HttpPost]
    public IActionResult CreateGoal([FromBody] CreateGoalDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // Отправляем ошибки клиенту
        }

        var goal = new Goals { Description = dto.Description };
        _context.Goals.Add(goal);
        _context.SaveChanges();
        return Ok(goal);
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
