using OnlineStoreManager.Domain.Entities;
using OnlineStoreManager.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DapperExtensions;
using DapperExtensions.Predicate;

namespace OnlineStoreManager.API.Services
{
    public class UserService
    {
        private GenericRepository<User> _userRepository;

        public UserService()
        {
            _userRepository = new GenericRepository<User>("OnlineStoreManager");
        }

        public User GetUserByIdentity(string authId)
        {
            User user = _userRepository.GetByPredicate(Predicates.Field<User>(u => u.AuthId, Operator.Eq, authId)).FirstOrDefault();
            return user;
        }

        public User Get(int id)
        {
            User user = _userRepository.Get(id);
            return user;
        }
    }
}