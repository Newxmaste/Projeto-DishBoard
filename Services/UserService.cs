using DishApi.Data;
using DishApi.Dto;
using DishApi.Models;

public class UserService : IUserService
{
    private readonly DishBoardContext dbcontext;

    public UserService(DishBoardContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    public List<User> GetAllUsers()
    {
        return dbcontext.Users.ToList();
    }

    public User? GetUserById(Guid id)
    {
        var user = dbcontext.Users.Find(id);

        return user;
    }

    public User AddUser(AddUserDto dto)
    {
        var newUser = new User()
        {
            Email = dto.Email,
            PasswordHash = dto.Password,
            Username = dto.Username,
            PhoneNumber = dto.PhoneNumber,
            ProfileImage = dto.ProfileImage
        };

        dbcontext.Users.Add(newUser);
        dbcontext.SaveChanges();

        return newUser;
    }

    public User? UpdateUser(UpdateUserDto dto, Guid id)
    {
        var user = dbcontext.Users.Find(id);

        if (user is null) return null;

        if (dto.NewEmail != null)
        {
            user.Email = dto.NewEmail;
        }

        if (dto.NewUserPassword != null)
        {
            user.PasswordHash = dto.NewUserPassword;
        }

        if (dto.NewUsername != null)
        {
            user.Username = dto.NewUsername;
        }

        if (dto.NewPhoneNumber != null)
        {
            user.PhoneNumber = dto.NewPhoneNumber;
        }

        if (dto.NewProfileImage != null)
        {
            user.ProfileImage = dto.NewProfileImage;
        }
        dbcontext.SaveChanges();

        return user;
    }

    public bool DeleteUser(Guid id)
    {
        var user = dbcontext.Users.Find(id);

        if (user is null) return false;

        dbcontext.Users.Remove(user);
        dbcontext.SaveChanges();

        return true;
}

}