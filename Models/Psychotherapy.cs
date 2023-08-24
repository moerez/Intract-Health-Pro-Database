using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models
{
    public class Psychotherapy 
    {
        public int Id { get; set; }

        public Client Client { get; set; } = null!;

        [Display(Name = "Stressed")]
        public bool Stressed { get; set; }

        [Display(Name = "Sad Or Feel Like Crying")]
        public bool Sad { get; set; }

        [Display(Name = "Nervous Or Depressed")]
        public bool NervousDepressed { get; set; }

        [Display(Name = "Irritable")]
        public bool Irritable { get; set; }

        [Display(Name = "Restless")]
        public bool Restless { get; set; }

        [Display(Name = "Having Difficulty Sleeping")]
        public bool SleepTrouble { get; set; }

        [Display(Name = "Experiencing FlashBacks")]
        public bool Flashbacks { get; set; }

        [Display(Name = "Nightmares")]
        public bool Nightmares { get; set; }

        [Display(Name = "Memory Problems")]
        public bool MemoryProblems { get; set; }

        [Display(Name = "Afraid Whilst Driving")]
        public bool AfraidDriving { get; set; }

        [Display(Name = "Afraid as a Passenger")]
        public bool AfraidPassenger { get; set; }

        [Display(Name = "Believe Relationships to be Affected")]
        public bool RelationshipsAffected { get; set; }

        [Display(Name = "Having Difficulties Carrying-Out Daily Activities")]
        public bool DifficultyWActivities { get; set; }

        [Display(Name = "Low Energy")]
        public bool LowEnergy { get;set; }

        [Display(Name = "Less Interest In Previously Enjoyed Activities")]
        public bool Apathy { get; set; }

        [Display(Name = "Avoid Activities/Situtions related to Accident/Injuries")]
        public bool Avoidance { get; set; }

        [Display(Name = "Other Symptoms And Notes")]
        public string? Other { get; set; }

    }
}
