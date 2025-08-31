using DishApi.Models;
using DishApi.Dto;

public interface IRestaurantService
{
    List<Restaurant> GetAllRestaurants();
    Restaurant? GetRestaurantById(Guid id);
    Restaurant AddRestaurant(AddRestaurantDto dto, Guid userId);

    bool DeleteRestaurant(Guid id);
}