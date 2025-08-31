using DishApi.Models;
using DishApi.Dto;
public interface IUserService
{
    List<User> GetAllUsers();
    User? GetUserById(Guid id);
    User AddUser(AddUserDto dto);
    User? UpdateUser( UpdateUserDto dto, Guid id);
    bool DeleteUser(Guid id);
}