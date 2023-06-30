using System;
using System.Collections.Generic;

namespace Healthcare.Models;

public partial class Admin
{
    public Guid? UniqueId { get; set; }

    public int AdminId { get; set; }

    public string? AdminName { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public long? Mobile { get; set; }

    public string? EmailId { get; set; }
}
