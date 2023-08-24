using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models
// Artour : added class because it was missing
{
    public class BodyTrauma
    {
        public int Id { get; set; }
        public Client Client { get; set; } = null!;

        [Display(Name = "Bruising")]
        public bool Bruising { get; set; }

        [Display(Name = "Bleeding")]
        public bool Bleeding { get; set; }

        [Display(Name = "Fracture")]
        public bool Fracture { get; set; }

        [Display(Name = "Loss of Contentiousness")]
        public bool LossOfContentiousness { get; set; }

        [Display(Name = "Hit to The Head")]
        public bool HitToTheHead { get; set; }

        [Display(Name = "None")]
        public bool None { get; set; }

        [Display(Name = "Did you feel pain right away?")]
        public bool PainRightAway { get; set; }
    }
}
