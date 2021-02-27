namespace SalesApplication.WEB.Providers
{
    using System;
    using System.Web.Security;
    using BLL.Models;
    using BLL.Services;
    using Models;

    public class CustomRoleProvider : RoleProvider
    {
        private readonly IUserService _userService ;

        public CustomRoleProvider()
        {
            _userService = new UserService("SalesDB");
        }

        public override bool IsUserInRole(string userName, string roleName)
        {
            // Получаем пользователя
            UserViewModel user = GetUserByEmail(userName);
            if (user != null && user.Role != null && user.Role.Name == roleName)
                return true;
            else
                return false;
        }

        public override string[] GetRolesForUser(string userName)
        {
            string[] roles = { };
            //Получаем пользователя
            UserViewModel user = GetUserByEmail(userName);
            if (user != null && user.Role != null)
            {
                // получаем роль
                roles = new[] {user.Role.Name};
            }

            return roles;
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }

        private UserViewModel GetUserByEmail(string userName)
        {
            return MapUserModelToUserViewModel(_userService.GetByEMail(userName));
        }

        private UserViewModel MapUserModelToUserViewModel(UserModel userModel)
        {
            return new UserViewModel
            {
                Email = userModel.Email,
                Password = userModel.Password,
                RoleId = userModel.RoleId,
                Role = new RoleViewModel
                {
                    Name = userModel.Role.Name
                }
            };
        }
    }
}