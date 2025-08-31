namespace DishApi.Dto
{
    public class AddUserDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Username { get; set; }
        public Guid? RestaurantId { get; set; }
        public string Role { get; set; } = "Uncategorized";
        public string? PhoneNumber { get; set; }
        public string? ProfileImage { get; set; }
    }
}