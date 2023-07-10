namespace TaskMgt.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public ApplicationUser UserId { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Owner { get; set; }
        public Priority Priority { get; set; }
    }

    public enum Priority
    {
        High = 1,
        Normal,
        Low
    }
}
