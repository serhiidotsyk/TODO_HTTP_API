using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TODO_HTTP_API.BusinessLogic.Interfaces;
using TODO_HTTP_API.BusinessLogic.Models;
using TODO_HTTP_API.DataAcceess;

namespace TODO_HTTP_API.BusinessLogic.Services
{
    public class UserService: IUserService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public UserService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UserModel GetUser(int userId)
        {
            UserModel userModel = null;
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                userModel = _mapper.Map<UserModel>(user);
            }
            return userModel;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            IEnumerable<UserModel> userModel = null;
            var users = _context.Users.ToList();
            if (users != null)
            {
                userModel = _mapper.Map<IEnumerable<UserModel>>(users);
            }
            return userModel;
        }
    }
}
