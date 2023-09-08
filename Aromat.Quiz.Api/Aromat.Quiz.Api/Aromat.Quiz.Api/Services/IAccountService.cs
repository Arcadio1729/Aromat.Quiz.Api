using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Authentication;
using Aromat.Quiz.Api.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Services
{
    public interface IAccountService
    {
        ActionResult<ReadUserWithTokenDto> LoginUser(LoginDto dto, bool changePassword);
        void ChangePassword(ClaimsPrincipal user,ChangePasswordDto dto);
        ActionResult<ReadUser> RegisterUser(RegisterUserDto dto);
        JwtSecurityToken GenerateJwt(LoginDto dto);
        Task<ReadUserDto> GetUserFromAccessToken(string accessToken);
        string GetRoles();
        string GetUsers();
        string GetUsersByCourse(int courseId);
        string GetUser(int userId);
        string GetUsersByRole(int roleId);
        Task RemoveUser(int userId);
        Task<string> AddRole(string roleName);
        string GetUserInfo(ClaimsPrincipal user);
        Task<ActionResult<UserWithToken>> RefreshToken([FromBody]RefreshRequest refreshRequest);

        Task<string> UpdateUser(UpdateUserDto updateUserDto);
        Task<string> CreateUser(AddUserDto addUserDto);
    }
}
