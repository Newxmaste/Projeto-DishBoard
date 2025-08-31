using DishApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DishApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RestaurantsController : ControllerBase
    {

        private readonly IRestaurantService restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        [HttpGet("GetAllRestaurants")]

        public IActionResult GetAllRestaurants()
        {
            var allRestaurants = restaurantService.GetAllRestaurants();

            return Ok(allRestaurants);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRestaurantById(Guid id)
        {
            var restaurant = restaurantService.GetRestaurantById(id);
            if (restaurant is null) return NotFound();

            return Ok(restaurant);
}



        [HttpPost]
        [Route("{id:guid}")]

        public IActionResult AddRestaurant(AddRestaurantDto dto, Guid id)
        {
            var newRestaurant = restaurantService.AddRestaurant(dto, id);

            if (newRestaurant is null) return NotFound();

            return Ok(newRestaurant);
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteUser(Guid id)
        {
            var deletedRestaurant = restaurantService.DeleteRestaurant(id);

            if (!deletedRestaurant) return NotFound();

            return Ok(deletedRestaurant);
        }
}

}