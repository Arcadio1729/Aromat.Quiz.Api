using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Authentication;
using Aromat.Quiz.Api.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Services
{
    public interface IAccountService
    {
        ActionResult<ReadUserWithTokenDto> LoginUser(LoginDto dto);
        ActionResult<ReadUser> RegisterUser(RegisterUserDto dto);
        JwtSecurityToken GenerateJwt(LoginDto dto);
        Task<ReadUserDto> GetUserFromAccessToken(string accessToken);
        string GetRoles();
        string GetUsers();
        string GetUsersByCourse(int courseId);
        string GetUser(int userId);
        Task RemoveUser(int userId);
        Task<string> AddRole(string roleName);
        Task<ActionResult<UserWithToken>> RefreshToken([FromBody]RefreshRequest refreshRequest);

        Task<string> UpdateUser(UpdateUserDto updateUserDto);
        Task<string> CreateUser(AddUserDto addUserDto);
    }
}
