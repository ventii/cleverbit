using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class LikeContext : DbContext
    {
        public LikeContext() : base("LikeDB")
        {

        }

        public DbSet<UserLike> UserLikes { get; set; }
    }
}
