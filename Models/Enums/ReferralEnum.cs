using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models.Enums
{
    public enum ReferralEnum
    {
        [Display(Name = "Family Doctor")]
        FamilyDoctor,
        Specialist,
        [Display(Name = "Orthopeadic Surgeon")]
        OrthopeadicSurgeon,
        [Display(Name = "Lawyer - Legal Representative")]
        Lawyer,
        [Display(Name = "Walk In Clinic")]
        WalkInClinic,
        [Display(Name = "Rehabilitation Centre")]
        RehabilitationCentre,
        Hospital,
        [Display(Name = "Friend/Family")]
        FriendFamily,
        Google,
        Facebook,
        Linkedin,
        Instagram,
        Twitter,
        Webinar,
        Youtube,
        [Display(Name = "Another Website/Link")]
        AnotherWebsiteLink,
        [Display(Name = "Radio/TV")]
        RadioTV,
        [Display(Name = "Magazine/News Paper")]
        MagazineNewsPaper,
        [Display(Name = "Flyer/Print Advertising")]
        FlyerPrintAdvertising,
        Poster,
        Other
    }
}