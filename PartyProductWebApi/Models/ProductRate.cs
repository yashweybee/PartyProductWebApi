using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PartyProductWebApi.Models;

public partial class ProductRate
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int Rate { get; set; }


    [JsonIgnore]
    public virtual Product Product { get; set; } = null!;
}
