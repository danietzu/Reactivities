using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reactivities.Blazor.Data
{
    public class Activity
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Venue { get; set; }

        public static List<string> Categories
        {
            get => new List<string> { "Drinks", "Culture", "Film", "Food", "Music", "Travel" };
        }
    }
}