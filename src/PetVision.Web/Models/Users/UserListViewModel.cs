using System.Collections.Generic;
using PetVision.Roles.Dto;
using PetVision.Users.Dto;

namespace PetVision.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}