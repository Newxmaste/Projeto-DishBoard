using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class RestaurantUser
{
    public Guid RestaurantId { get; set; }

    public Guid UserId { get; set; }

    public string Role { get; set; } = null!;

    public virtual Restaurant Restaurant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
