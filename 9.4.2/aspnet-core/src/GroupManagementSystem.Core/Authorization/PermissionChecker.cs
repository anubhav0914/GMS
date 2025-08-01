using Abp.Authorization;
using GroupManagementSystem.Authorization.Roles;
using GroupManagementSystem.Authorization.Users;

namespace GroupManagementSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
