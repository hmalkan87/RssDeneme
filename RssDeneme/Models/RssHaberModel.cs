using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RssDeneme.Models
{
    public class RssHaberModel
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string pubDate { get; set; }
        public string Link { get; set; }
    }
}