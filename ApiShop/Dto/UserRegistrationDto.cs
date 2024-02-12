namespace ApiShop.Dto
{
    public class UserRegistrationDto
    {    
        public string UserSurname { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserPatronymic { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public string UserLogin { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
    }
}
