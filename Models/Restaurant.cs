using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class Restaurant
{
    public Guid RestaurantId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public Guid CreatedByUserId { get; set; }

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual ICollection<RestaurantUser> RestaurantUsers { get; set; } = new List<RestaurantUser>();
}
