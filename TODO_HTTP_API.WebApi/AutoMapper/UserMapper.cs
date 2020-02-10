using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO_HTTP_API.BusinessLogic.Models;
using TODO_HTTP_API.DataAcceess.Entities;

namespace TODO_HTTP_API.WebApi.AutoMapper
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
