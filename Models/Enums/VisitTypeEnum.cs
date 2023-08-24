using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models.Enums
{
    public enum VisitTypeEnum
    {
        [Display(Name = "Rehab")]
        Rehab,

        [Display(Name = "Family Doctor")]
        FamilyDoctor,

        [Display(Name = "Walk-In Clinic")]
        WalkInclinic,

        [Display(Name = "Hospital")]
        Hospital,

        [Display(Name = "Other")]
        Other
    }
}