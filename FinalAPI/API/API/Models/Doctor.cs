using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Doctor
{
    public int? UserId { get; set; }

    public int DoctorId { get; set; }

    public string? Name { get; set; }

    public string? Specialist { get; set; }

    public string? Address { get; set; }

    public long? Mobilenum { get; set; }

    public string? EmailId { get; set; }

    public string? Designation { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
