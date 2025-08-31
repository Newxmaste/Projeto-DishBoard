using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class Product
{
    public Guid ProductId { get; set; }

    public int StatusProductId { get; set; }

    public int CategoryId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual StatusProduct StatusProduct { get; set; } = null!;
}
