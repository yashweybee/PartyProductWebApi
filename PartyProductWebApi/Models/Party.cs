using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PartyProductWebApi.Models;

public partial class Party
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;


    [JsonIgnore]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
