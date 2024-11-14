using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? TodoOwner { get; set; }
        public string? Description { get; set; }
        public bool isCompleted { get; set; } = false;
    }
}
