using API.Models;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    
    public class LikeController : ApiController
    {

        [HttpGet]
        [Route("api/like/{pageName}")]        
        public IHttpActionResult GetPageLikes(string pageName)
        {
            List<string> userNameList = UserLikeBL.GetPageLikes(pageName);

            return Ok(new LikeResponse { Status = "success", JSON = new { userNameList = userNameList } });
        }

        [HttpPost]
        [Route("api/like")]        
        public IHttpActionResult RecordLike([FromBody] LikeRequest like)
        {
            //anti forgery request token
            //user access

            int likeCount = -1;

            if(like.IsLike)
            {
                likeCount = UserLikeBL.AddPageLike(like.PageName, like.UserName);
            }
            else
            {
                likeCount = UserLikeBL.RemovePageLike(like.PageName, like.UserName);
            }

            if (likeCount > -1)
            {
                return Ok(new LikeResponse { Status = "success", JSON = new { updated = true, count = likeCount } });
            }

            return Ok(new LikeResponse { Status = "success", JSON = new { updated = false, count = likeCount } });
        }
       
    }
}
