using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class LikeRequest
    {
        public string PageName { get; set; }
        public string UserName { get; set; }
        public bool IsLike { get; set; }
    }
}