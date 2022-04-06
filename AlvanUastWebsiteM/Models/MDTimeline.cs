using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlvanUastWebsiteM.Models
{
    public class MDTimeline
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public DateTime EntekhabVahed { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public DateTime ShoroeKelasha { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public DateTime HazfoEzafe { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public DateTime PayaneKelasha { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public DateTime Emtehanat { get; set; }
    }

    [ModelMetadataType(typeof(MDTimeline))]
    public partial class Timeline { }
}
