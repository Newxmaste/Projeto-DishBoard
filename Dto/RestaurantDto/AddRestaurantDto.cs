namespace DishApi.Dto
{
    public class AddRestaurantDto
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
    }
}