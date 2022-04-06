using System;
using System.Collections.Generic;

namespace AlvanUastWebsiteM.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public string Body { get; set; }
    }
}
