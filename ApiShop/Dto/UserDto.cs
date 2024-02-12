namespace ApiShop.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserSurname { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserPatronymic { get; set; } = null!;
        public string UserRole { get; set; } = null!;
    }
}
