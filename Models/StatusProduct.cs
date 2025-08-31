using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class StatusProduct
{
    public int StatusProductId { get; set; }

    public string? ProductNote { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
