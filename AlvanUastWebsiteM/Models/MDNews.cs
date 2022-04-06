using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlvanUastWebsiteM.Models
{
    public class MDNews
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

        [Required(ErrorMessage = "لطفا تصویر را انتخاب و بارگذاری کنید")]
        [MaxLength(250, ErrorMessage = "طول فیلد حداکثر 250 کاراکتر است")]
        [StringLength(1000, ErrorMessage = "طول فیلد حداکثر 1000 کاراکتر است")]
        public string Image { get; set; }

    }

    [ModelMetadataType(typeof(MDNews))]
    public partial class News { }
}
