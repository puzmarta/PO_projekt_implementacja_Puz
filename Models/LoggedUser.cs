using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class LoggedUser
{
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public DateOnly? AccountCreationDate { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
