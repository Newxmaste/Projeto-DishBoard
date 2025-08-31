using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class StatusOrder
{
    public int StatusOrderId { get; set; }

    public string? ProductNote { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
