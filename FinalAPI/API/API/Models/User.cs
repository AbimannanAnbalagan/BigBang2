using System;
using System.Collections.Generic;

namespace API.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Name { get; set; }

    public string? EmailId { get; set; }

    public byte[]? Password { get; set; }

    public byte[]? HashKey { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
