using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models.Enums
{
    public enum DeliveryMethodEnum
    {
        [Display(Name = "Telephone")]
        Telephone,
        [Display(Name = "Email")]
        Email,
        [Display(Name = "Fax")]
        Fax,
        [Display(Name = "Fax via other source	")]
        FaxViaOtherSource,
        [Display(Name = "Regular Mail")]
        RegularMail,
        [Display(Name = "Courier")]
        Courier,
        [Display(Name = "Hand Delivered")]
        HandDelivered,
    }
}