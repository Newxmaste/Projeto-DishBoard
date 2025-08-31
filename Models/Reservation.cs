using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class Reservation
{
    public Guid ReservationId { get; set; }

    public Guid TableId { get; set; }

    public int StatusReservationId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerLastName { get; set; } = null!;

    public string? CustomerPhone { get; set; }

    public int NumberOfPeople { get; set; }

    public DateTime ReservationTime { get; set; }

    public int? EstimatedDuration { get; set; }

    public virtual StatusReservation StatusReservation { get; set; } = null!;

    public virtual Table Table { get; set; } = null!;
}
