using System;
using System.Linq;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Domain.Services;

namespace UnitOfWorkExample.Web.Helpers.Security
{
    public class RoleProvider : System.Web.Security.RoleProvider
    {
        private IUserService _userService;
        private IRoleService _roleService;

        public RoleProvider(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public RoleProvider()
        {
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var user = _userService.GetByUsername(username);
            if (user == null)
            {
                return false;
            }
            if (user.Roles == null)
            {
                return false;
            }
            return user.Roles.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).Contains(roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            var user = _userService.GetByUsername(username);
            if (user == null)
            {
                return null;
            }
            if (user.Roles == null)
            {
                return null;
            }
            return user.Roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }

        public override void CreateRole(string roleName)
        {
            _roleService.Create(new Role{Name = roleName});
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            _roleService.Delete(_roleService.GetAll().First(t => t.Name == roleName).Id);
            return true;
        }

        public override bool RoleExists(string roleName)
        {
            return _roleService.GetAll().Any(t => t.Name == roleName);
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return _roleService.GetAll().Select(t => t.Name).ToArray();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string ApplicationName
        {
            get { return "Example"; }
            set { throw new System.NotImplementedException(); }
        }
    }
}