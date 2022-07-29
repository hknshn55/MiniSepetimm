using Microsoft.AspNetCore.Identity;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos;
using MiniSepetim.Entities.Dtos.RegisterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Abstract
{
    public interface IAuthService
    {
        Task<SignInResult> Login(LoginDto model);
        Task<IdentityResult> CustomerRegister(CustomerRegisterDto customerRegisterDto);
        Task<IdentityResult> SellerRegister(SellerRegisterDto sellerRegisterDto);
        Task<IdentityResult> AdminRegister(AdminRegisterDto model);
        Task<IdentityResult> AddRoleToUser(AppIdentityUser user, string roleName);
        Task<AppIdentityUser> GetUser(string userName);
        AppIdentityUser GetUserByEmail(string email);
        Task<string> GetRoleByUserName(string userName);
        Task Logout();
    }
}
