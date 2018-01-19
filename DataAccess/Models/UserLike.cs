using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UserLike
    {
        public UserLike() { }

        public UserLike(string pageName, string userName)
        {
            PageName = pageName;
            UserName = userName;
        }

        public int Id { get; set; }
        public string PageName { get; set; }
        public string UserName { get; set; }

        

        
    }
}
