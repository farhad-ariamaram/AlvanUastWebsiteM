using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlvanUastWebsiteM.Models
{
    public class MDNotice
    {
        [Required(ErrorMessage ="این فیلد اجباری است")]
        [MaxLength(1000,ErrorMessage ="طول فیلد حداکثر 1000 کاراکتر است")]
        [StringLength(1000, ErrorMessage = "طول فیلد حداکثر 1000 کاراکتر است")]
        public string Title { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(60000, ErrorMessage = "طول فیلد حداکثر 60000 کاراکتر است")]
        [StringLength(60000, ErrorMessage = "طول فیلد حداکثر 60000 کاراکتر است")]
        public string Body { get; set; }
    }

    [ModelMetadataType(typeof(MDNotice))]
    public partial class Notice { }
}
