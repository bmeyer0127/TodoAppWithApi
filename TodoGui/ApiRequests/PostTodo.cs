namespace TodoGui.ApiRequests
{
    public class PostTodo
    {
        public string Title { get; set; } = string.Empty;
        public string? TodoOwner { get; set; }
        public string? Description { get; set; }
        public bool isCompleted { get; set; } = false;
    }
}
