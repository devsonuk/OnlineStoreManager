using Microsoft.AspNet.Identity;
using OnlineStoreManager.API.Services;
using OnlineStoreManager.Domain.Entities;
using OnlineStoreManager.Repository.Generic;
using System.Web.Http;


namespace OnlineStoreManager.API.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly UserService _userService;

        public UsersController()
        {
            _userService = new UserService();
        }

        // GET: Users/Details/5
        [HttpGet]
        public User Get()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            User user = _userService.GetUserByIdentity(userId);
            return user;
        }
    }
}
