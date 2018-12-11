using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroportBusinessLogic.Interfaces
{
    public interface IRoleProvider
    {
        string[] GetRolesForUser(string username);
        void CreateRole(string roleName);
        bool IsUserInRole(string username, string roleName);
        void AddUsersToRoles(string[] usernames, string[] roleNames);
        bool DeleteRole(string roleName, bool throwOnPopulatedRole);
        string[] FindUsersInRole(string roleName, string usernameToMatch);
        string[] GetAllRoles();
        string[] GetUsersInRole(string roleName);
        void RemoveUsersFromRoles(string[] usernames, string[] roleNames);
        bool RoleExists(string roleName);

    }
}
