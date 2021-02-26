using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Stone.Core.DTOs.UserDTO;
using Stone.Core.Services.Email;
using Stone.Core.Services.Interfaces;
using Stone.DataLayer.Context;
using Stone.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Core.Services
{
    public class UserService : IUserService
    {
        private StoneContext _context;
        private AppSettings _appSettings;
        private IEmailSender _emailSender;


        public UserService(Stone.DataLayer.Context.StoneContext context, IOptions<AppSettings> appSettings, IEmailSender emailSender)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _emailSender = emailSender;
        }

        public async Task<ProfileViewModelDto> Activated(CheckActiveCodeViewModelDto checkAC)
        {
            if (checkAC.APIAvtiveCode == checkAC.UserAvtiveCode)
            {
                User user = await ActiveCodeTrue(checkAC.Mobile);
                return new ProfileViewModelDto()
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Mobile = user.Mobile,
                    Email = user.Email,
                    Password = user.Password,
                    RegisterDate = user.RegisterDate
                };
            }
            return null;

        }

        public async Task<User> ActiveCodeTrue(string mobile)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Mobile == mobile && !u.IsAtive);
            user.IsAtive = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<CheckActiveCodeViewModelDto> AddUser(UserViewModelDto registerViewModel)
        {
            await RemoveNotActivatedMobile(registerViewModel.Mobile);
            Generator.Generator generator = new Generator.Generator();
            User user = new User()
            {
                Name = registerViewModel.Name,
                Mobile = registerViewModel.Mobile,
                Email = registerViewModel.Email.ToLower(),
                Password = registerViewModel.Password,
                IsAtive = false,
                UserBan = false,
                AvtiveCode = generator.AvtiveCodeGenarator()
            };
            var message = new Message(new string[] { "siamak.biglari.a@gmail.com" }, "Test email", "This is the content from our email.");
            _emailSender.SendEmail(message);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new CheckActiveCodeViewModelDto()
            {
                Name = user.Name,
                Mobile = user.Mobile,
                APIAvtiveCode = user.AvtiveCode
            };
        }

        public async Task<UserViewModelDto> GetUserByMobile(string mobile)
        {
            return await _context.Users.Where(u => u.Mobile == mobile).Select(s => new UserViewModelDto()
            {
                UserId = s.UserId,
                Name = s.Name,
                Mobile = s.Mobile,
                Email = s.Email,
                Password = s.Password,
                RegisterDate = s.RegisterDate
            }).FirstOrDefaultAsync();

        }

        public async Task<bool> IsExistMobile(string mobile)
        {
            return await _context.Users.AnyAsync(u => u.Mobile == mobile && u.IsAtive);
        }

        public async Task<ProfileViewModelDto> Login(LoginViewModelDto loginViewModelDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync
                (u => u.Mobile == loginViewModelDto.Mobile && u.Password==loginViewModelDto.Password && u.IsAtive==true);
            //user not found
            if (user == null)
                return null;

            //If user was found Generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new ProfileViewModelDto()
            {
                UserId = user.UserId,
                Mobile = user.Mobile,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                RegisterDate = user.RegisterDate,
                Token = tokenHandler.WriteToken(token)
            };
        }

        public async Task RemoveNotActivatedMobile(string mobile)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Mobile == mobile && !u.IsAtive);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }

        }
    }
}
