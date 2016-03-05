using System.Collections.Generic;
using System.Linq;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Domain.Repositories;

namespace UnitOfWorkExample.Domain.Services
{

    public interface IUserService
    {
        IList<User> GetAll();
        User GetById(int id);
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
    public class UserService : IUserService
    {
        private IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IList<User> GetAll()
        {
            return userRepository.GetAll().ToList();
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public void Create(User user)
        {
            userRepository.Create(user);
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }
    }
}
