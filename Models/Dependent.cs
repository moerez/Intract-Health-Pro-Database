using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models
{
    public class Dependent
    {

        public int Id { get; set; }
        public Client Client { get; set; } = null!;

        [Display(Name = "Do You Have to look after anyone")]
        public string? Person { get; set; }

        [Display(Name = "Does Client use a Wheelchair")]
        public bool Wheelchair { get; set; }

        public string? Details { get; set; }
    }
}
