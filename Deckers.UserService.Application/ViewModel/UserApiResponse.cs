using System;
using System.Collections.Generic;
using System.Text;

namespace Deckers.UserService.Application.ViewModel
{
    public class UserApiResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
