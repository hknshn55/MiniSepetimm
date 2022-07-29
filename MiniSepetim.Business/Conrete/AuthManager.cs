using Microsoft.AspNetCore.Identity;
using MiniSepetim.Business.Abstract;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos;
using MiniSepetim.Entities.Dtos.RegisterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Conrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly RoleManager<AppIdentityRole> _roleManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        public AuthManager(UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> roleManager, SignInManager<AppIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> AddRoleToUser(AppIdentityUser user, string roleName)
        {
            var role = _roleManager.Roles.FirstOrDefault(x=>x.Name == roleName); //Roller tablosundan verilen role göre getirme işlemi yap.
            if (role == null) // Eğer böyler bir rol yoksa
            {
                await _roleManager.CreateAsync( //Roles tablosunda böyle bir rol yoksa oluştur
                new AppIdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper() //Kullanıcı büyük küçük karakter kullanabilir biz standartlaştırmak için normalize ederiz.
                });
               
            }
            return await _userManager.AddToRoleAsync(user, roleName); //Kullanıcıya rolü direk ekle
        }

        public async Task<IdentityResult> AdminRegister(AdminRegisterDto model)
        {
            var user = new AppIdentityUser { Email = model.Email, UserName = model.UserName, PhoneNumber = model.PhoneNumber };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await AddRoleToUser(user, "Admin");
            }
            return result;
        }

        public async Task<IdentityResult> CustomerRegister(CustomerRegisterDto customerRegisterDto)
        {
            var user = new AppIdentityUser { UserName = customerRegisterDto.UserName, Email = customerRegisterDto.Email };
            var customer = new Customer { FirstName = customerRegisterDto.FirstName, LastName = customerRegisterDto.LastName, PhoneNumber = customerRegisterDto.PhoneNumber,State=true};
            user.Customer = customer;
            var result = await _userManager.CreateAsync(user, customerRegisterDto.Password);

            if (result.Succeeded)
            {
                await AddRoleToUser(user, "Customer");
            }
            return result;
        }

        public async Task<string> GetRoleByUserName(string userName)
        {
            var user = await GetUser(userName);
            var roleList = (await _userManager.GetRolesAsync(user));
            if (roleList.Count > 0)
            {
                return roleList[0];
            }
            return null;
        }

        public async Task<AppIdentityUser> GetUser(string userName)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
            
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public AppIdentityUser GetUserByEmail(string email)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Email == email);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public async Task<SignInResult> Login(LoginDto model)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user is null){
                return new SignInResult();
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> SellerRegister(SellerRegisterDto sellerRegisterDto)
        {
            var user = new AppIdentityUser 
            { 
                UserName = sellerRegisterDto.UserName, 
                Email = sellerRegisterDto.Email 
            };
            var seller = new Seller 
            { 
                Name = sellerRegisterDto.SellerName, 
                
                Adress=sellerRegisterDto.Adress 
            };
            user.Seller = seller; //Gelen user bir satıcı, bu user a satıcı bilgilerini ver
            var result = await _userManager.CreateAsync(user, sellerRegisterDto.Password);
            if (result.Succeeded)
            {
                await AddRoleToUser(user, "Seller");
            }
            return result;
        }
    }
}
