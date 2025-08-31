using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class Shift
{
    public Guid ShiftsId { get; set; }

    public Guid UserId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string ShiftType { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual User User { get; set; } = null!;
}
