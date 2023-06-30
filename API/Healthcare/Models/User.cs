using System;
using System.Collections.Generic;

namespace Healthcare.Models;

public partial class User
{
    public Guid? UniqueId { get; set; }

    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public long? Mobile { get; set; }

    public string? EmailId { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
