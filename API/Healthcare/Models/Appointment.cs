using System;
using System.Collections.Generic;

namespace Healthcare.Models;

public partial class Appointment
{
    public Guid? UniqueId { get; set; }

    public int AppointmentId { get; set; }

    public int? UserId { get; set; }

    public int? PatientAge { get; set; }

    public string? PatientGender { get; set; }

    public int? DoctorId { get; set; }

    public DateTime? Date { get; set; }

    public string? Status { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual User? User { get; set; }
}
