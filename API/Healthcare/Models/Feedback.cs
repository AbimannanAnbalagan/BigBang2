using System;
using System.Collections.Generic;

namespace Healthcare.Models;

public partial class Feedback
{
    public Guid? UniqueId { get; set; }

    public int FeedbackId { get; set; }

    public int? AppointmentId { get; set; }

    public string? Feedback1 { get; set; }

    public DateTime? Date { get; set; }

    public virtual Appointment? Appointment { get; set; }
}
