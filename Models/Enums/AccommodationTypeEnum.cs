using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models.Enums
{
    public enum AccommodationTypeEnum
    {
        [Display(Name = "Single Detached")]
        SingleDetached,
        [Display(Name = "Semi Detached")]
        Semi_Detached,
        Condominium,
        Apartment,
        Townhouse,
        [Display(Name = "Basement Apartment")]
        BasementApartment,
        Bachelor,
        [Display(Name = "Room with Shared Common Areas")]
        SingleRoomwithSharedCommonAreas
    }
}
