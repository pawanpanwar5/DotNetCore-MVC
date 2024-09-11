using ConcertBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.WebHost.ViewModels
{
    public class ConcertViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        //public string ImageUrl { get; set; }
        public DateTime DateTime { get; set; }
        public string VenueName { get; set; }
        //public Venue Venue { get; set; }
        public string ArtistName { get; set; }
        //public Artist Artist { get; set; }
    }
}
