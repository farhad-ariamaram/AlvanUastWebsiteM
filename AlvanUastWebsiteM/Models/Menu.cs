using System;
using System.Collections.Generic;

namespace AlvanUastWebsiteM.Models
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public string Image { get; set; }
        public string Body { get; set; }
    }
}
