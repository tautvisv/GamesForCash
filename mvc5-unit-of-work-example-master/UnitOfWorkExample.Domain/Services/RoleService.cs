using System.Collections.Generic;
using System.Linq;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Domain.Repositories;

namespace UnitOfWorkExample.Domain.Services
{

    public interface IRoleService
    {
        IList<Role> GetAll();
        Role GetById(int id);
        void Create(Role role);
        void Update(Role role);
        void Delete(int id);
    }
    public class RoleService : IRoleService
    {
        private IRepository<Role> roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public IList<Role> GetAll()
        {
            return roleRepository.GetAll().ToList();
        }

        public Role GetById(int id)
        {
            return roleRepository.GetById(id);
        }

        public void Create(Role role)
        {
            roleRepository.Update(role);
        }

        public void Update(Role role)
        {
            roleRepository.Update(role);
        }

        public void Delete(int id)
        {
            roleRepository.Delete(id);
        }
    }
}
