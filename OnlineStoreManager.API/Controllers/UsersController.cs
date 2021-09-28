using Microsoft.AspNet.Identity;
using OnlineStoreManager.Domain.Entities;
using OnlineStoreManager.Repository.Repository;
using System.Web;
using System.Web.Http;


namespace OnlineStoreManager.API.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly UserRepository _userRepository;

        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        // GET: Users/Details/5
        [HttpGet]
        public User Get()
        {
            var userId = RequestContext.Principal.Identity.GetUserId();
            return _userRepository.Get(userId);
        }

    }
}
