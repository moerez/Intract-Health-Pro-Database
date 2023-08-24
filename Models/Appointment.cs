using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Models
{
    [Index(nameof(Start))]
    public class Appointment
    {
        public int Id { get; set; }

        public Client Client { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Display(Name = "Duration (minutes)")]
        public int Duration { get; set; } = 30;

        [Display(Name = "Start Time")]
        public DateTime Start { get; set; }

        public DateTime End
        {
            get
            {
                return Start.AddMinutes(Duration);
            }
        }

    }
}