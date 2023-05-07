using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Authentication;
using Aromat.Quiz.Api.Model.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aromat.Quiz.Api.Exceptions;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Aromat.Quiz.Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly QuizDbContext _context;
        private IPasswordHasher<User> _hasher;
        private readonly AuthenticationSettings _settings;
        private readonly JWTSettings _jwtsettings;

        public AccountService(
            QuizDbContext context,
            IPasswordHasher<User> hasher,
            AuthenticationSettings settings,
            IOptions<JWTSettings> jwtSettings)
        {
            this._context = context;
            this._hasher = hasher;
            this._settings = settings;
            this._jwtsettings = jwtSettings.Value;
        }

        public ActionResult<ReadUser> RegisterUser(RegisterUserDto userDto)
        {
            Students student = new Students
            {
                Name = userDto.Email
            };

            Role role = this._context.Roles.FirstOrDefault(r => r.Id == userDto.RoleId);

            User user = new User
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Role=role,
                RoleId=userDto.RoleId
            };

            student.User = user;

            var hashedPassword = this._hasher.HashPassword(user, userDto.Password);
            user.PasswordHash = hashedPassword;

            this._context.Students.Add(student);
            this._context.SaveChanges();

            return new ReadUser { Email = user.Email, Role = user.RoleId };
        }
        public JwtSecurityToken GenerateJwt(User user,LoginDto loginDto)
        {
            UserWithToken userWithToken = null;

            if(user is null)
                throw new BadRequestException("Invalid username or password");  


            var results = this._hasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);

            if (results == PasswordVerificationResult.Failed)
                throw new BadRequestException("Invalid username or password");

            var studentId = this._context
                .Students
                .FirstOrDefault(s => s.UserId == user.Id).Id;

            var coursesstudents = this._context
                    .CoursesStudents
                    .Where(cs => cs.StudentsId == studentId)
                    .Select(x => x.CourseDetailsId).ToList();

            List<ReadCourseDto> courses = new List<ReadCourseDto>();

            foreach (var cs in coursesstudents)
            {
                var course = this._context
                    .CourseDetails
                    .Select(cd => new
                    {
                        Id=cd.Id,
                        Name=cd.Name
                    })
                    .FirstOrDefault(cd => cd.Id == cs);

                courses.Add(new ReadCourseDto { Name = course.Name });
            }
            
            var json = JsonConvert.SerializeObject(courses);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role,$"{user.Role.Name}"),
                new Claim("Courses",json)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._settings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(this._settings.JwtExpireDays);

            var token = new JwtSecurityToken(this._settings.JwtIssuer,
                this._settings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: credentials);

            return token;
        }
        private string GenerateAccessToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(userId))
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
       
        #region old loginuser
        //public ActionResult<ReadUser> LoginUser(LoginDto dto)
        //{
        //    var user = this._context.Users
        //       .Include(u => u.Role)
        //       .FirstOrDefault(u => u.Email == dto.Email);

        //    var token = this.GenerateJwt(user,dto);
        //    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        //    UserWithToken userWithToken = null;

        //    RefreshToken refreshToken = new RefreshToken
        //    {
        //        ExpiryDate = token.ValidTo,
        //        Token = tokenHandler.WriteToken(token)
        //    };

        //    userWithToken = new UserWithToken(user);
        //    userWithToken.RefreshToken = refreshToken.Token;

        //    if (userWithToken == null)
        //    {
        //        throw new NotFoundException("User with token not found.");
        //    }

        //    userWithToken.AccessToken = tokenHandler.WriteToken(token);

        //    return new ReadUser
        //    {
        //        AccessToken = userWithToken.AccessToken,
        //        Email = userWithToken.Email,
        //        FirstName = userWithToken.FirstName,
        //        LastName = userWithToken.LastName,
        //        RefreshToken = userWithToken.RefreshToken,
        //        Id = userWithToken.Id,
        //        Role=userWithToken.Role.Id
        //    };

        //}

        #endregion
        
        public ActionResult<ReadUserWithTokenDto> LoginUser(LoginDto dto)
        {
            var user = this._context.Users
               .Include(u => u.Role)
               .FirstOrDefault(u => u.Email == dto.Email);

            var token = this.GenerateJwt(user, dto);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            UserWithToken userWithToken = null;

            RefreshToken refreshToken = new RefreshToken
            {
                ExpiryDate = token.ValidTo,
                Token = tokenHandler.WriteToken(token)
            };

            userWithToken = new UserWithToken(user);
            userWithToken.RefreshToken = refreshToken.Token;

            if (userWithToken == null)
            {
                throw new NotFoundException("User with token not found.");
            }

            userWithToken.AccessToken = tokenHandler.WriteToken(token);

            return new ReadUserWithTokenDto
            {
                AccessToken = userWithToken.AccessToken,
                Email = userWithToken.Email,
                FirstName = userWithToken.FirstName,
                LastName = userWithToken.LastName,
                RefreshToken = userWithToken.RefreshToken,
                Id = userWithToken.Id,
                Role = userWithToken.Role.Name
            };
        }
        public async Task<User> GetUserFromAccessToken(string accessToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                SecurityToken securityToken;
                var principle = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var userId = principle.FindFirst(ClaimTypes.Name)?.Value;

                    return await _context
                        .Users
                        .Include(u => u.Role)
                        .Where(u => u.Id == Convert.ToInt32(userId))
                        .FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {
                return new User();
            }

            return new User();
        }
        public async Task<ActionResult<UserWithToken>> RefreshToken(RefreshRequest refreshRequest)
        {
            User user = await GetUserFromAccessToken(refreshRequest.AccessToken);

            if (user != null && ValidateRefreshToken(user, refreshRequest.RefreshToken))
            {
                UserWithToken userWithToken = new UserWithToken(user);
                userWithToken.AccessToken = GenerateAccessToken(user.Id);

                return userWithToken;
            }

            return null;
        }

        private bool ValidateRefreshToken(User user, string refreshToken)
        {

            RefreshToken refreshTokenUser = this._context
                .RefreshTokens
                .Where(rt => rt.Token == refreshToken)
                .OrderByDescending(rt => rt.ExpiryDate)
                .FirstOrDefault();

            if (refreshTokenUser != null && 
                refreshTokenUser.UserId == user.Id && 
                refreshTokenUser.ExpiryDate > DateTime.UtcNow)
            {
                return true;
            }

            return false;
        }

        public JwtSecurityToken GenerateJwt(LoginDto dto)
        {
            throw new NotImplementedException();
        }

        Task<ReadUserDto> IAccountService.GetUserFromAccessToken(string accessToken)
        {
            throw new NotImplementedException();
        }

        public string GetRoles()
        {
            var roles = this._context.Roles;
            var json = JsonConvert.SerializeObject(roles);

            return json;
        }
        public string GetUsers()
        {
            var users = this._context.Users.Select(
                u => new ReadUserDto
                {
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Id = u.Id,
                    Role = u.Role.Name
                }).ToList();

            var json = JsonConvert.SerializeObject(users);

            return json;
        }
        public string GetUser(int userId)
        {
            var user = this._context.Users
                .Select(
                        u => new ReadUserDto
                        {
                            Email = u.Email,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Id = u.Id,
                            Role = u.Role.Name
                        })
                .FirstOrDefault(u => u.Id == userId);

            var json = JsonConvert.SerializeObject(user);

            return json;
        }

        public async Task<string> UpdateUser(UpdateUserDto updateUserDto)
        {
            try
            {
                User user = this._context.Users.FirstOrDefault(u => updateUserDto.Id == u.Id);

                user.Email = updateUserDto.Email;
                user.FirstName = updateUserDto.FirstName;
                user.LastName = updateUserDto.LastName;
                user.Role = this._context.Roles.FirstOrDefault(r => r.Name == updateUserDto.Role);

                this._context.Users.Update(user);
                await this._context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return "Something went wrong";
            }

            return "";
        }
        
        public async Task<string> CreateUser(AddUserDto addUserDto)
        {
            try
            {
                User user = new User
                {
                    Email = addUserDto.Email,
                    FirstName = addUserDto.FirstName,
                    LastName = addUserDto.LastName,
                    Role = this._context.Roles.FirstOrDefault(r => r.Name == addUserDto.Role),
                    RoleId = this._context.Roles.FirstOrDefault(r => r.Name == addUserDto.Role).Id
                };

                this._context.Users.Add(user);
            }
            catch(Exception e)
            {
                return "Something went wrong";
            }

            return "";
        } 


        public async Task<string> AddRole(string roleName)
        {
            try
            {
                var role = new Role() { Name = roleName };
                await this._context.Roles.AddAsync(role);
                await this._context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return "Something went wrong";
            }
            return "";
        }
        public async Task RemoveUser(int userId)
        {
            var user = this._context.Users.FirstOrDefault(u => u.Id == userId);

            if (user is null)
                throw new NotFoundException($"Course with id {userId} not found.");

            this._context.Users.Remove(user);
            this._context.SaveChanges();
        }

        public string GetUsersByCourse(int courseId)
        {
            var users = this._context.CoursesStudents
                .Where(cs => cs.CourseDetailsId == courseId)
                .Include(cs => cs.Student)
                .Include(cs=>cs.Student.User)
                .Select(cs => cs.Student)
                .Select(s=>new ReadUserDto 
                { 
                    FirstName=s.User.FirstName,
                    LastName=s.User.LastName,
                    Email=s.User.Email,
                    Role=s.User.Role.Name,
                    Id=s.User.Id
                })
                .ToList();

            var json = JsonConvert.SerializeObject(users);

            return json;
        }
    }
}
