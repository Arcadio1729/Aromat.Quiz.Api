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

namespace Aromat.Quiz.Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly QuizDbContext _context;
        private IPasswordHasher<User> _hasher;
        private readonly AuthenticationSettings _settings;

        public AccountService(
            QuizDbContext context,
            IPasswordHasher<User> hasher,
            AuthenticationSettings settings)
        {
            this._context = context;
            this._hasher = hasher;
            this._settings = settings;
        }

        public void RegisterUser(RegisterUserDto userDto)
        {
            var newUser = new User()
            {
                Email = userDto.Email,
                RoleId = userDto.RoleId
            };

            var hashedPassword = this._hasher.HashPassword(newUser, userDto.Password);

            newUser.PasswordHash = hashedPassword;

            Students student = new Students
            {
                Name = userDto.Email,
                User = newUser
            };

            this._context.Students.Add(student);
            this._context.SaveChanges();
        }
    
        public string GenerateJwt(LoginDto loginDto)
        {
            var user = this._context.Users
                .Include(u=>u.Role)
                .FirstOrDefault(u => u.Email == loginDto.Email);

            if(user is null)
                throw new BadRequestException("Invalid username or password");

            var results = this._hasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);

            if (results == PasswordVerificationResult.Failed)
                throw new BadRequestException("Invalid username or password");

            var studentId = this._context.Students.FirstOrDefault(s => s.UserId == user.Id).Id;

            var coursesstudents = this._context
                    .CoursesStudents
                    .Where(cs => cs.StudentsId == studentId)
                    .Select(x => x.CourseDetailsId).ToList();

            List<CourseDetails> courses = new List<CourseDetails>();

            foreach (var cs in coursesstudents)
            {
                var course = this._context.CourseDetails.FirstOrDefault(cd => cd.Id == cs);
                courses.Add(course);
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

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
