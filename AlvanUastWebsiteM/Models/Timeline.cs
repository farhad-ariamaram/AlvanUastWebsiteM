using System;
using System.Collections.Generic;

namespace AlvanUastWebsiteM.Models
{
    public partial class Timeline
    {
        public int Id { get; set; }
        public int Nimsal { get; set; }
        public DateTime EntekhabVahed { get; set; }
        public DateTime ShoroeKelasha { get; set; }
        public DateTime HazfoEzafe { get; set; }
        public DateTime PayaneKelasha { get; set; }
        public DateTime Emtehanat { get; set; }
    }
}
