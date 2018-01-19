using BusinessLayer;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class UserLikeBL
    {     

        /// <summary>
        /// Retrieves list of UserNames that liked the specified page
        /// </summary>
        /// <param name="pageName">name of page</param>
        /// <returns>List of UserName</returns>
        public static List<string> GetPageLikes(string pageName)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName), "Parameter cannot be null");
            }

            pageName = pageName.Trim();


            List<string> userNameList = new List<string>();
            try
            {
                using (var context = new LikeContext())
                {
                    userNameList = context.UserLikes.Where(x => x.PageName.ToLower() == pageName).Select(x => x.UserName).ToList();
                }
            }
            catch (Exception e)
            {
                //log error
            }

            return userNameList;

        }

        public static int RemovePageLike(string pageName, string userName)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName), "Parameter cannot be null");
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName), "Parameter cannot be null");
            }

            pageName = pageName.Trim();
            userName = userName.Trim();

            try
            {
                using (var context = new LikeContext())
                {
                    var toRemove = context.UserLikes.SingleOrDefault(x => x.PageName.ToLower() == pageName.ToLower() && x.UserName.ToLower() == userName.ToLower());

                    context.UserLikes.Remove(toRemove);
                    context.SaveChanges();

                    return context.UserLikes.Count(x => x.PageName.ToLower() == pageName.ToLower());

                }
            }
            catch (Exception e)
            {
                //log error                
            }

            return -1;
        }

        /// <summary>
        /// Adds like for page, if it does not exist already. 
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="userName"></param>
        /// <returns>Count of page likes by all users</returns>
        public static int AddPageLike(string pageName, string userName)
        {
            if(string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName), "Parameter cannot be null");
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName), "Parameter cannot be null");
            }

            pageName = pageName.Trim();
            userName = userName.Trim();

            try
            {
                using (var context = new LikeContext())
                {
                    if (!context.UserLikes.Any(x => x.PageName.ToLower() == pageName.ToLower() && x.UserName.ToLower() == userName.ToLower()))
                    {
                        context.UserLikes.Add(new UserLike(pageName, userName));
                        context.SaveChanges();

                        return context.UserLikes.Count(x => x.PageName.ToLower() == pageName.ToLower());
                        
                    }
                }
            }
            catch (Exception e)
            {
                //log error                
            }

            return -1;

        }
    }
}
