using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public Client Client { get; set; } = null!;

        [Display(Name = "If Client has Cats, How many?")]
        public int? Cat { get; set; }
        [Display(Name = "If Client has Dogs, How many?")]
        public int? Dog { get; set; }

        [Display(Name = "Other Animals/Notes?")]
        public string? Details { get; set; }

        override public string ToString() => $"{Cat} cats, {Dog} dogs, {Details}";
    }
}
