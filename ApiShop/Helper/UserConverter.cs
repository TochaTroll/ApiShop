using ApiShop.Context;
using ApiShop.Dto;
using ApiShop.Model;

namespace ApiShop.Helper
{
    public class UserConverter
    {
        public static User ConverterUser(ShopContext shopContext, UserRegistrationDto userDto)
        {        
            var user = (from u in shopContext.Users
                        select new User
                        {                           
                            UserName = userDto.UserName,
                            UserLogin = userDto.UserLogin,
                            UserPassword = userDto.UserPassword,
                            UserPatronymic = userDto.UserPatronymic,
                            UserRole = shopContext.Roles.Where(x => x.RoleName == userDto.UserRole).Select(x => x.RoleId).First(),
                            UserSurname = userDto.UserSurname,
                        }).First();
            return user;
        }
    }
}
