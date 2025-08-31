using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class Table
{
    public Guid TableId { get; set; }

    public Guid UserId { get; set; }

    public int StatusTableId { get; set; }

    public int TableNumber { get; set; }

    public int Capacity { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual StatusTable StatusTable { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
