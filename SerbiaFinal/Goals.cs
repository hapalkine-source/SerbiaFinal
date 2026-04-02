using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
namespace SerbiaFinal
{
    public class Goals
    { 
        public int Id {  get; set; }
        

        public class Goal
        {
        public int Id { get; set; }

        [Required(ErrorMessage = "Описание обязательно")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "От 3 до 100 символов")]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        }

        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
