using Stone.Core.DTOs.UserDTO;
using Stone.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsExistMobile(string mobile);
        Task RemoveNotActivatedMobile(string mobile);
        Task<CheckActiveCodeViewModelDto> AddUser(UserViewModelDto registerViewModel);
        Task<ProfileViewModelDto> Activated(CheckActiveCodeViewModelDto checkAC);
        Task<UserViewModelDto> GetUserByMobile(string mobile);
        Task<User> ActiveCodeTrue(string mobile);
        Task<ProfileViewModelDto> Login(LoginViewModelDto loginViewModelDto);
   
    }
}
