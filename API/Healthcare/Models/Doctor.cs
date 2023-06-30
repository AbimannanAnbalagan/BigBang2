using System;
using System.Collections.Generic;

namespace Healthcare.Models;

public partial class Doctor
{
    public Guid? UniqueId { get; set; }

    public int DoctorId { get; set; }

    public string? DoctorName { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public long? Mobile { get; set; }

    public string? EmailId { get; set; }

    public string? Gender { get; set; }

    public string? Designation { get; set; }

    public string? Specialisation { get; set; }

    public string? Image { get; set; }

    public string? Status { get; set; }

    public DateTime? RequestedDate { get; set; }

    public DateTime? RespondedDate { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
