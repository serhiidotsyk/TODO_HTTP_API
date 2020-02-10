using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO_HTTP_API.BusinessLogic.Interfaces;
using TODO_HTTP_API.BusinessLogic.Models;
using TODO_HTTP_API.DataAcceess.Entities;

namespace TODO_HTTP_API.Tests.FakeService
{
    public class UserServiceFake: IUserService
    {
        private readonly List<UserModel> _users;
        public UserServiceFake()
        {
            _users = new List<UserModel>
            {
                new UserModel { Id = 1, Name = "Lucas"},
                new UserModel { Id = 2, Name = "Dan"},
                new UserModel { Id = 3, Name = "HZ"},
                new UserModel { Id = 4, Name = "France"},
                new UserModel { Id = 5, Name = "Ivan"},
            };
        }
        public IEnumerable<UserModel> GetUsers()
        {
            return _users;
        }
        public UserModel GetUser(int id)
        {
            return _users.Where(u => u.Id == id).SingleOrDefault();
        }
    }
}
