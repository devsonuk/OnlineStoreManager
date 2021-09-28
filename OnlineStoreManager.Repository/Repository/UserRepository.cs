using OnlineStoreManager.Domain.Entities;
using OnlineStoreManager.Repository.Generic;

namespace OnlineStoreManager.Repository.Repository
{
    public class UserRepository
    {
        private readonly GenericRepository<User> _genericRepository;
        public UserRepository()
        {

            _genericRepository = new GenericRepository<User>("OnlineStoreManager");
        }

        public User Get(string id)
        {
            return _genericRepository.Get("[dbo].[usp_GetUser]", id);
        }

    }
}
