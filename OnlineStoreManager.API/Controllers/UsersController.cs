using Microsoft.AspNet.Identity;
using OnlineStoreManager.Domain.Entities;
using OnlineStoreManager.Repository.Generic;
using System.Web.Http;


namespace OnlineStoreManager.API.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly GenericRepository<User> _userRepository;

        public UsersController()
        {
            _userRepository = new GenericRepository<User>("OnlineStoreManager");
        }

        // GET: Users/Details/5
        [HttpGet]
        public User Get()
        {
            var userId = RequestContext.Principal.Identity.GetUserId();
            var user = _userRepository.Get(userId);
            return user;
        }
    }
}
