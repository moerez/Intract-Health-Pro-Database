using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InteractHealthProDatabase.Models.Enums;

namespace InteractHealthProDatabase.Models
{
    public class EmailMessage
    {
        [Key]
        public string Uid { get; set; } = null!;

        public DateTime DateTime { get; set; }

        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client? Client { get; set; }

        public EmailTypeEnum EmailType { get; set; } = EmailTypeEnum.Unknown;

        public string Subject { get; set; } = null!;

        public string? Body { get; set; }

        public string From { get; set; } = null!;

        public string To { get; set; } = null!;
    }
}