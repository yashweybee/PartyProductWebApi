using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PartyProductWebApi.Models;

public partial class AssignParty
{
    public int Id { get; set; }

    public int PartyId { get; set; }

    public int ProductId { get; set; }


    [JsonIgnore]
    public virtual Party Party { get; set; } = null!;

    [JsonIgnore]
    public virtual Product Product { get; set; } = null!;
}
