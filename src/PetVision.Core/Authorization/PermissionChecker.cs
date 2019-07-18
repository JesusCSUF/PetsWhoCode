using Abp.Authorization;
using PetVision.Authorization.Roles;
using PetVision.Authorization.Users;

namespace PetVision.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
