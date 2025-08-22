namespace CarClinic.Application.DTOs
{
    public class UpdateUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Admin or User
    }
}
