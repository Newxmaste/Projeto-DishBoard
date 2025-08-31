using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class Report
{
    public Guid ReportId { get; set; }

    public Guid ShiftsId { get; set; }

    public int? TotalOrders { get; set; }

    public decimal? TotalRevenue { get; set; }

    public virtual Shift Shifts { get; set; } = null!;
}
