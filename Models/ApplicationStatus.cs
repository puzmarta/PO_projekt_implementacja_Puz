using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class ApplicationStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
