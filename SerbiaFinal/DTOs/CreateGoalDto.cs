using System.ComponentModel.DataAnnotations;

public class CreateGoalDto
{
    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Минимум 3 символа!")]
    public string Description { get; set; } = string.Empty;
}
