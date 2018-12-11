using AeroportBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using AeroportBusinessLogic.Enums;
using AeroportBusinessLogic.Interfaces;

namespace AeroportBusinessLogic.RoleProvidersMethods
{
    public class RoleProviderMethods : IRoleProvider
    {
        public void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            using (FlightContext db = new FlightContext())
            {
                // Получаем пользователя
                Manager user = db.Managers.FirstOrDefault(u => u.Email == username);
                if (user != null)
                {
                    roles = new string[] { user.Role.ToString().ToUpper()};
                }
                return roles;
            }
        }

        public string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public bool IsUserInRole(string username, string roleName)
        {
            using (FlightContext db = new FlightContext())
            {
                // Получаем пользователя
                Manager user = db.Managers.FirstOrDefault(u => u.Email == username);

                if (user != null && user.Role.ToString().ToUpper() == roleName.ToUpper())
                    return true;
                else
                    return false;
            }
        }

        public void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
