using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Patient
{
    public int? UserId { get; set; }

    public int PatientId { get; set; }

    public string? PatientName { get; set; }

    public string? Address { get; set; }

    public long? Mobilenum { get; set; }

    public string? EmailId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual User? User { get; set; }
}
