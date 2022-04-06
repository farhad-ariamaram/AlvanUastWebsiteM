using System;
using System.Collections.Generic;

namespace AlvanUastWebsiteM.Models
{
    public partial class Notice
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
    }
}
