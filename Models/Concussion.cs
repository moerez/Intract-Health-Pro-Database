using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models
{
    public class Concussion
    {
        public int Id { get; set; }
        public Client Client { get; set; } = null!;

        [Display(Name = "Headaches or Migranes")]
        public bool HeadAches { get; set; }

        [Display(Name = "Blurry Vision or Visual Problems")]
        public bool Vision { get; set; }

        [Display(Name = "Amnesia")]
        public bool Amnesia { get; set; }

        [Display(Name = "Loss of Smell or Taste")]
        public bool Smell { get; set; }

        [Display(Name = "Ringing or Buzzing in Ears")]
        public bool Tinitus { get; set; }

        [Display(Name = "Suffer From Seizures")]
        public bool Seizures { get; set; }

        [Display(Name = "Dizziness")]
        public bool Dizziness { get; set; }

        [Display(Name = "Loss of Co-Ordination or Balance")]
        public bool Balance { get; set; }

        [Display(Name = "Hand Tremors")]
        public bool Tremors { get; set; }

        [Display(Name = "Nausea")]
        public bool Nausea { get; set; }

        [Display(Name = "Blackouts")]
        public bool Blackouts { get; set; }

        [Display(Name = "Difficulty Handling Multiple Tasks")]
        public bool Tasks { get; set; }

        [Display(Name = "Reduced Drive or Motivation")]
        public bool Motivation { get; set; }

        [Display(Name = "Difficulty Finishing Tasks")]
        public bool FinishTasks { get; set; }

        [Display(Name = "Less Assertive")]
        public bool Assert { get; set; }

        [Display(Name = "Forgetful")]
        public bool Forgetful { get; set;}

        [Display(Name = "Reduced Attention Span")]
        public bool AttentionSpan { get;set; }

        [Display(Name = "Difficulty Anticipating Others")]
        public bool AnticipateOthers { get;set; }

        [Display(Name = "Difficulty with Problem Solving")]
        public bool ProblemSolving { get; set; }

        [Display(Name = "Less Mental Stamina")]
        public bool MentalStamina { get;set; }

        [Display(Name = "Difficulty With Reading")]
        public bool Reading { get; set;}

        [Display(Name = "Performance Inconsistences at Work")]
        public bool Performance { get; set;}

        [Display(Name = "Language Difficulty")]
        public bool LanguageDifficulty { get; set; }

        [Display(Name = "Verbal Learning Problems")]
        public bool Verbal { get; set; }

        [Display(Name = "Impaired Judgement")]
        public bool ImpairedJudgement { get; set; }

        [Display(Name = "Slower Reaction Time")]
        public bool Reactions { get; set; }

        [Display(Name = "Need Notes or Day-Timer to Remember Home or Work Activites")]
        public bool NotesTimer { get; set;}

        [Display(Name = "Abnormal Levels of Anxiety")]
        public bool AbnormalAnxiety { get; set; }

        [Display(Name = "Less Diplomatic Than Usual")]
        public bool Rude { get; set; }

        [Display(Name = "Perosnality Changes")]
        public bool Personality { get; set; }

        [Display(Name = "Mood Swings")]
        public bool Mood { get; set; }

        [Display(Name = "Depression")]
        public bool Depression { get; set; }

        [Display(Name = "Indifference to Other People")]
        public bool Indifference { get; set; }

        [Display(Name = "Fatigue")]
        public bool Fatigue { get; set; }

        [Display(Name = "More Shallow Relationships")]
        public bool Shallow { get; set;}

        [Display(Name = "Mental Inflexibility")]
        public bool MentalFlex { get; set;}

        [Display(Name = "Notes")]
        public string? Note { get; set; }
    }
}
