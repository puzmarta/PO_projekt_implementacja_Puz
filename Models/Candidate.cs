using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Candidate
{
    public int Id { get; set; }

    public int GenderFk { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public DateOnly? DateOfIssuingDiploma { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? PlaceOfBirth { get; set; }

    public string? City { get; set; }

    public string? HighSchoolCity { get; set; }

    public string? HighSchoolName { get; set; }

    public string? HouseNumber { get; set; }

    public string? Street { get; set; }

    public string IdentityDocumentNumber { get; set; } = null!;

    public string? HighSchoolDiplomaNumber { get; set; }

    public string? IssuingAuthority { get; set; }

    public string? Pesel { get; set; }

    public int LoggedUserFk { get; set; }

    public int IdentityDocumentTypeFk { get; set; }

    public int HighSchoolTypeFk { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Gender Gender { get; set; } = null!;

    public virtual HighSchoolType HighSchoolType { get; set; } = null!;

    public virtual IdentityDocumentType IdentityDocumentType { get; set; } = null!;

    public virtual LoggedUser LoggedUser { get; set; } = null!;

    public virtual ICollection<RankingList> RankingLists { get; set; } = new List<RankingList>();
}
