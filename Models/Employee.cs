using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Position { get; set; }

    public int LoggedUserFk { get; set; }

    public virtual LoggedUser LoggedUserFkNavigation { get; set; } = null!;
}
