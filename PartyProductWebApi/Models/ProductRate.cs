using System;
using System.Collections.Generic;

namespace PartyProductWebApi.Models;

public partial class ProductRate
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int Rate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
