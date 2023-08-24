using System.ComponentModel.DataAnnotations;
using InteractHealthProDatabase.MyTools;

namespace InteractHealthProDatabase.Models
{
    public abstract class BaseContact
    {
        private string _contactName = null!;
        [Required]
        [Display(Name = "Contact Name")]
        [MaxLength(100)]
        public string ContactName
        {
            get
            {
                return _contactName;
            }
            set
            {
                _contactName = MyFormatter.FormatNameToTitleCase(value);
            }
        }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; } = null!;

        private string? _cellPhone { get; set; }
        [Display(Name = "Cell Phone")]
        public string? CellPhone
        {
            get
            {
                return MyFormatter.FormatPhoneNumber(_cellPhone);
            }
            set
            {
                _cellPhone = MyFormatter.Strip(value);
            }
        }

        private string? _telephone { get; set; }
        public string? Telephone
        {
            get
            {
                return MyFormatter.FormatPhoneNumber(_telephone);
            }
            set
            {
                _telephone = MyFormatter.Strip(value);
            }
        }

        private string? _fax { get; set; }
        public string? Fax
        {
            get
            {
                return MyFormatter.FormatPhoneNumber(_fax);
            }
            set
            {
                _fax = MyFormatter.Strip(value);
            }
        }

        private string? _address;
        public string? Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (value != null)
                    _address = MyFormatter.FormatNameToTitleCase(value);
            }
        }

        private string? _city { get; set; }
        public string? City
        {
            get
            {
                return _city;
            }
            set
            {
                if (value != null)
                    _city = MyFormatter.FormatNameToTitleCase(value);
            }
        }

        private string? _region { get; set; }
        public string? Region
        {
            get
            {
                return _region;
            }
            set
            {
                if (value != null)
                    _region = MyFormatter.FormatNameToTitleCase(value);
            }
        }

        private string? _country { get; set; }
        public string? Country
        {
            get
            {
                return _country;
            }
            set
            {
                if (value != null)
                    _country = MyFormatter.FormatNameToTitleCase(value);
            }
        }

        private string? _postalCode { get; set; }
        [Display(Name = "Postal Code")]
        public string? PostalCode
        {
            get
            {
                return MyFormatter.FormatPostalCode(_postalCode);
            }
            set
            {
                _postalCode = MyFormatter.Strip(value);
            }
        }
    }
}