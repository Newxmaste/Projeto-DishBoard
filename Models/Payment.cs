using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public Guid OrderId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public decimal AmountPaid { get; set; }

    public decimal? ChangeAmount { get; set; }

    public bool? IsPaid { get; set; }

    public DateTime PaymentDate { get; set; }

    public virtual Order Order { get; set; } = null!;
}
