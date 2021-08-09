using Deckers.UserService.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deckers.UserService.Application.Serviecs
{
    public class UserServiceDetails:IUserService
    {
        public UserApiResponse<UserViewModel> GetUserDetails(string uname, string pwd)
        {
            var result = new UserViewModel()
            {
                result = 1,
                roleId = 1,
                roleName = "Admin"
            };
            //var result = _dbContext.Users.AsQueryable().Where(x => x.userName == uname && x.password == pwd).AsNoTracking().Select(y => new UserAuthViewModel()
            //{
            //    //result = y.,
            //    //roleId = y.,
            //    //roleName = y
            //}).AsList();
            return new UserApiResponse<UserViewModel> { Data = result, Success = true, StatusCode = 200, Message = (result != null && result.result == 0) ? "NoRecordsFound" : null };
        }
    }
}
