using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoGui.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? TodoOwner { get; set; }
        public string? Description { get; set; }
        public bool isCompleted { get; set; }
    }
}
