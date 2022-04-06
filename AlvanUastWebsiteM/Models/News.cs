using System;
using System.Collections.Generic;

namespace AlvanUastWebsiteM.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int NewsCategoryId { get; set; }
        public string Image { get; set; }
        public string Body { get; set; }
        public string Pics { get; set; }

        public virtual NewsCategory NewsCategory { get; set; }
    }
}
