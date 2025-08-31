using DishApi.Data;
using DishApi.Dto;
using DishApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;


public class RestaurantService : IRestaurantService
{

    private readonly DishBoardContext dbContext;
    private readonly IUserService userService;

    public RestaurantService(DishBoardContext dbcontext, IUserService userService)
    {
        this.dbContext = dbcontext;
        this.userService = userService;

    }

    public List<Restaurant> GetAllRestaurants()
    {
        return dbContext.Restaurants.ToList();
    }

    public Restaurant? GetRestaurantById(Guid id)
    {
        var restaurant = dbContext.Restaurants.Find();

        return restaurant;
    }

    public Restaurant AddRestaurant(AddRestaurantDto dto, Guid userId)
    {
        var currentUser = userService.GetUserById(userId);
        if (currentUser is null)
        {
            throw new Exception();
        }
        var newRestaurant = new Restaurant()
        {
            Name = dto.Name,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            CreatedByUserId = currentUser.Id
        };

        dbContext.Restaurants.Add(newRestaurant);
        dbContext.SaveChanges();

        return newRestaurant;
    }

    public bool DeleteRestaurant(Guid id)
    {
        var restaurant = dbContext.Restaurants.Find(id);

        if (restaurant is null) return false;

        dbContext.Restaurants.Remove(restaurant);
        dbContext.SaveChanges();

        return true;
    }
}