namespace InteractHealthProDatabase.Models
{
    public class EventViewModel
    {
        public Int64 Id { get; set; }

        public String Title { get; set; } = null!;

        public String Start { get; set; } = null!;

        public String End { get; set; } = null!;

        public bool AllDay { get; set; }

        public int PublicId { get; set; }
    }
}