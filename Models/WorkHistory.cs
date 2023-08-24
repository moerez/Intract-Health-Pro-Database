using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractHealthProDatabase.Models
{
    public class WorkHistory
    {
        public int Id { get; set; }

        public Client Client { get; set; } = null!;

        public string? Position { get; set; }

        public string? Company { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public DateTime? From { get; set; }

        public DateTime? Until { get; set; }

        public string? Details { get; set; }

    }
}