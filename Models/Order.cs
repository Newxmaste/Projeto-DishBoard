using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class Order
{
    public Guid OrderId { get; set; }

    public Guid UserId { get; set; }

    public Guid TableId { get; set; }

    public int StatusOrderId { get; set; }

    public Guid ShiftsId { get; set; }

    public DateTime OrderDate { get; set; }

    public string? Details { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Shift Shifts { get; set; } = null!;

    public virtual StatusOrder StatusOrder { get; set; } = null!;

    public virtual Table Table { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
