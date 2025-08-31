using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Username { get; set; } = null!;

    public Guid? RestaurantId { get; set; }

    public int StatusWorkerId { get; set; }

    public string Role { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ProfileImage { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<RestaurantUser> RestaurantUsers { get; set; } = new List<RestaurantUser>();

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();

    public virtual StatusWorker StatusWorker { get; set; } = null!;

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();
}
