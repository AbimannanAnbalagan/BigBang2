using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string? Feedback1 { get; set; }

    public string? Email { get; set; }
}
