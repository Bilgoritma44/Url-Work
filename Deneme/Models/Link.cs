using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Deneme.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }

        public string Code { get; set; }
        public string ShortUrl { get; set; }
    }
}