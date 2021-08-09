using Deckers.UserService.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deckers.UserService.Application.Serviecs
{
   public interface IUserService
    {
        UserApiResponse<UserViewModel> GetUserDetails(string uname, string pwd);
    }
}
