using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class StatusWorker
{
    public int StatusWorkerId { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
