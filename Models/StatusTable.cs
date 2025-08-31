using System;
using System.Collections.Generic;

namespace DishApi.Models;

public partial class StatusTable
{
    public int StatusTableId { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();
}
