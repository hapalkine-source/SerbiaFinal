namespace SerbiaFinal
{
    public class Goals
    { 
        public int Id {  get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
