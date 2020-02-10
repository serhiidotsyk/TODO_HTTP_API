using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TODO_HTTP_API.BusinessLogic.Models;

namespace TODO_HTTP_API.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUser(int userId);
    }
}
