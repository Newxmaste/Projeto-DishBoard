using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class StatusReservation
{
    public int StatusReservationId { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
