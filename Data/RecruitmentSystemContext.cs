using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PO_projekt_implementacja_Puz.Models;

namespace PO_projekt_implementacja_Puz.Data;

public partial class RecruitmentSystemContext : DbContext
{
    public RecruitmentSystemContext()
    {
    }

    public RecruitmentSystemContext(DbContextOptions<RecruitmentSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicTitle> AcademicTitles { get; set; }

    public virtual DbSet<AnswerMapping> AnswerMappings { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<DegreeLevel> DegreeLevels { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DrawingAdmissionExam> DrawingAdmissionExams { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<FieldOfStudy> FieldOfStudies { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<GraduationDiploma> GraduationDiplomas { get; set; }

    public virtual DbSet<HighSchoolDiploma> HighSchoolDiplomas { get; set; }

    public virtual DbSet<HighSchoolType> HighSchoolTypes { get; set; }

    public virtual DbSet<IdentityDocumentType> IdentityDocumentTypes { get; set; }

    public virtual DbSet<LoggedUser> LoggedUsers { get; set; }

    public virtual DbSet<OlympiadSubject> OlympiadSubjects { get; set; }

    public virtual DbSet<OlympiadWinnerDiploma> OlympiadWinnerDiplomas { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionPool> QuestionPools { get; set; }

    public virtual DbSet<RankingList> RankingLists { get; set; }

    public virtual DbSet<Recruitment> Recruitments { get; set; }

    public virtual DbSet<RecruitmentCriterion> RecruitmentCriteria { get; set; }

    public virtual DbSet<SecondDegreeAdmissionExam> SecondDegreeAdmissionExams { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<StudyForm> StudyForms { get; set; }

    public virtual DbSet<StudySubject> StudySubjects { get; set; }

    public virtual DbSet<TalentStudyCompletionCertificate> TalentStudyCompletionCertificates { get; set; }

    public virtual DbSet<University> Universities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RecruitmentSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Academic__3214EC27AB76CD9F");

            entity.ToTable("Academic_Title");

            entity.HasIndex(e => e.Name, "UQ__Academic__72E12F1BF3306C1E").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<AnswerMapping>(entity =>
        {
            entity.HasKey(e => new { e.QuestionFk, e.Answer, e.FieldOfStudyFk }).HasName("PK__Answer_M__431982FB80938C0A");

            entity.ToTable("Answer_Mapping");

            entity.Property(e => e.QuestionFk).HasColumnName("Question_FK");
            entity.Property(e => e.Answer)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FieldOfStudyFk).HasColumnName("Field_Of_Study_FK");

            entity.HasOne(d => d.FieldOfStudyFkNavigation).WithMany(p => p.AnswerMappings)
                .HasForeignKey(d => d.FieldOfStudyFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Answer_Ma__Field__14270015");

            entity.HasOne(d => d.QuestionFkNavigation).WithMany(p => p.AnswerMappings)
                .HasForeignKey(d => d.QuestionFk)
                .HasConstraintName("FK__Answer_Ma__Quest__1332DBDC");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC27952D5D87");

            entity.ToTable("Application");

            entity.HasIndex(e => e.ApplicationIdentifier, "UQ__Applicat__CF2240AAB4FE8FAB").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApplicationIdentifier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Application_Identifier");
            entity.Property(e => e.ApplicationStatusFk).HasColumnName("Application_Status_FK");
            entity.Property(e => e.CandidateFk).HasColumnName("Candidate_FK");
            entity.Property(e => e.DocumentFk).HasColumnName("Document_FK");
            entity.Property(e => e.HighSchoolDiplomaFk).HasColumnName("High_School_Diploma_FK");
            entity.Property(e => e.RecruitmentFk).HasColumnName("Recruitment_FK");
            entity.Property(e => e.RecruitmentIndex).HasColumnName("Recruitment_Index");

            entity.HasOne(d => d.ApplicationStatus).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicationStatusFk)
                .HasConstraintName("FK__Applicati__Appli__6383C8BA");

            entity.HasOne(d => d.Candidate).WithMany(p => p.Applications)
                .HasForeignKey(d => d.CandidateFk)
                .HasConstraintName("FK__Applicati__Candi__60A75C0F");

            entity.HasOne(d => d.Document).WithMany(p => p.Applications)
                .HasForeignKey(d => d.DocumentFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKApplicationDocument");

            entity.HasOne(d => d.HighSchoolDiploma).WithMany(p => p.Applications)
                .HasForeignKey(d => d.HighSchoolDiplomaFk)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Applicati__High___628FA481");

            entity.HasOne(d => d.Recruitment).WithMany(p => p.Applications)
                .HasForeignKey(d => d.RecruitmentFk)
                .HasConstraintName("FK__Applicati__Recru__619B8048");
        });

        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC273A8C56AF");

            entity.ToTable("Application_Status");

            entity.HasIndex(e => e.Name, "UQ__Applicat__72E12F1BD16062EF").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Candidat__3214EC27FFB65839");

            entity.ToTable("Candidate");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_of_Birth");
            entity.Property(e => e.DateOfIssuingDiploma).HasColumnName("Date_of_Issuing_Diploma");
            entity.Property(e => e.GenderFk).HasColumnName("Gender_FK");
            entity.Property(e => e.HighSchoolCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("High_School_City");
            entity.Property(e => e.HighSchoolDiplomaNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("High_School_Diploma_Number");
            entity.Property(e => e.HighSchoolName)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("High_School_Name");
            entity.Property(e => e.HighSchoolTypeFk).HasColumnName("High_School_Type_FK");
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("House_Number");
            entity.Property(e => e.IdentityDocumentNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Identity_Document_Number");
            entity.Property(e => e.IdentityDocumentTypeFk).HasColumnName("Identity_Document_Type_FK");
            entity.Property(e => e.IssuingAuthority)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Issuing_Authority");
            entity.Property(e => e.LoggedUserFk).HasColumnName("Logged_User_FK");
            entity.Property(e => e.Pesel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PESEL");
            entity.Property(e => e.PlaceOfBirth)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Place_of_Birth");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Postal_Code");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.GenderFkNavigation).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.GenderFk)
                .HasConstraintName("FK__Candidate__Gende__534D60F1");

            entity.HasOne(d => d.HighSchoolTypeFkNavigation).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.HighSchoolTypeFk)
                .HasConstraintName("FK__Candidate__High___5629CD9C");

            entity.HasOne(d => d.IdentityDocumentTypeFkNavigation).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.IdentityDocumentTypeFk)
                .HasConstraintName("FK__Candidate__Ident__5535A963");

            entity.HasOne(d => d.LoggedUserFkNavigation).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.LoggedUserFk)
                .HasConstraintName("FK__Candidate__Logge__5441852A");

            entity.HasMany(d => d.RankingListFks).WithMany(p => p.CandidateFks)
                .UsingEntity<Dictionary<string, object>>(
                    "CandidateRankingList",
                    r => r.HasOne<RankingList>().WithMany()
                        .HasForeignKey("RankingListFk")
                        .HasConstraintName("FK__Candidate__Ranki__10566F31"),
                    l => l.HasOne<Candidate>().WithMany()
                        .HasForeignKey("CandidateFk")
                        .HasConstraintName("FK__Candidate__Candi__0F624AF8"),
                    j =>
                    {
                        j.HasKey("CandidateFk", "RankingListFk").HasName("PK__Candidat__66485A3291153FBB");
                        j.ToTable("Candidate_Ranking_List");
                        j.IndexerProperty<int>("CandidateFk").HasColumnName("Candidate_FK");
                        j.IndexerProperty<int>("RankingListFk").HasColumnName("Ranking_List_FK");
                    });
        });

        modelBuilder.Entity<DegreeLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Degree_L__3214EC27E41CF630");

            entity.ToTable("Degree_Level");

            entity.HasIndex(e => e.Name, "UQ__Degree_L__72E12F1B77986F34").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC2743239C0F");

            entity.ToTable("Document");

            entity.HasIndex(e => e.Name, "UQ__Document__72E12F1B58E556F9").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApplicationFk).HasColumnName("Application_FK");
            entity.Property(e => e.CreationDate).HasColumnName("Creation_Date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.ApplicationFkNavigation).WithMany(p => p.Documents)
                .HasForeignKey(d => d.ApplicationFk)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Document__Applic__6754599E");
        });

        modelBuilder.Entity<DrawingAdmissionExam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drawing___3214EC27ED0F1389");

            entity.ToTable("Drawing_Admission_Exam");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExamFk).HasColumnName("Exam_FK");

            entity.HasOne(d => d.ExamFkNavigation).WithMany(p => p.DrawingAdmissionExams)
                .HasForeignKey(d => d.ExamFk)
                .HasConstraintName("FK__Drawing_A__Exam___09A971A2");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC273366341B");

            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LoggedUserFk).HasColumnName("Logged_User_FK");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.LoggedUserFkNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.LoggedUserFk)
                .HasConstraintName("FK__Employee__Logged__76969D2E");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exam__3214EC27918D22CF");

            entity.ToTable("Exam");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DocumentFk).HasColumnName("Document_FK");
            entity.Property(e => e.GradeFk).HasColumnName("Grade_FK");

            entity.HasOne(d => d.DocumentFkNavigation).WithMany(p => p.Exams)
                .HasForeignKey(d => d.DocumentFk)
                .HasConstraintName("FK__Exam__Document_F__05D8E0BE");

            entity.HasOne(d => d.GradeFkNavigation).WithMany(p => p.Exams)
                .HasForeignKey(d => d.GradeFk)
                .HasConstraintName("FK__Exam__Grade_FK__06CD04F7");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Faculty__3214EC279AAC4696");

            entity.ToTable("Faculty");

            entity.HasIndex(e => e.FacultyName, "UQ__Faculty__A6DEF55A99B49C8F").IsUnique();

            entity.HasIndex(e => e.FacultyNumber, "UQ__Faculty__E62F7FACED458CE7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FacultyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Faculty_Name");
            entity.Property(e => e.FacultyNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Faculty_Number");
            entity.Property(e => e.UniversityFk).HasColumnName("University_FK");

            entity.HasOne(d => d.UniversityFkNavigation).WithMany(p => p.Faculties)
                .HasForeignKey(d => d.UniversityFk)
                .HasConstraintName("FK__Faculty__Univers__45F365D3");
        });

        modelBuilder.Entity<FieldOfStudy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Field_Of__3214EC27886009CC");

            entity.ToTable("Field_Of_Study");

            entity.HasIndex(e => e.FieldName, "UQ__Field_Of__2E1288C1339423FD").IsUnique();

            entity.HasIndex(e => e.FieldAbbreviation, "UQ__Field_Of__D1560A3DBD4C23FD").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AcademicTitleFk).HasColumnName("Academic_Title_FK");
            entity.Property(e => e.AdmissionLimit).HasColumnName("Admission_Limit");
            entity.Property(e => e.CourseCards)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Course_Cards");
            entity.Property(e => e.DegreeLevelFk).HasColumnName("Degree_Level_FK");
            entity.Property(e => e.FacultyFk).HasColumnName("Faculty_FK");
            entity.Property(e => e.FieldAbbreviation)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Field_Abbreviation");
            entity.Property(e => e.FieldDescription)
                .HasColumnType("text")
                .HasColumnName("Field_Description");
            entity.Property(e => e.FieldName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Field_Name");
            entity.Property(e => e.StudyFormFk).HasColumnName("Study_Form_FK");
            entity.Property(e => e.StudyPlan)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Study_Plan");
            entity.Property(e => e.StudyProgram)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Study_Program");

            entity.HasOne(d => d.AcademicTitleFkNavigation).WithMany(p => p.FieldOfStudies)
                .HasForeignKey(d => d.AcademicTitleFk)
                .HasConstraintName("FK__Field_Of___Acade__4D94879B");

            entity.HasOne(d => d.DegreeLevelFkNavigation).WithMany(p => p.FieldOfStudies)
                .HasForeignKey(d => d.DegreeLevelFk)
                .HasConstraintName("FK__Field_Of___Degre__4CA06362");

            entity.HasOne(d => d.FacultyFkNavigation).WithMany(p => p.FieldOfStudies)
                .HasForeignKey(d => d.FacultyFk)
                .HasConstraintName("FK__Field_Of___Facul__4AB81AF0");

            entity.HasOne(d => d.StudyFormFkNavigation).WithMany(p => p.FieldOfStudies)
                .HasForeignKey(d => d.StudyFormFk)
                .HasConstraintName("FK__Field_Of___Study__4BAC3F29");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gender__3214EC27BBE7BB78");

            entity.ToTable("Gender");

            entity.HasIndex(e => e.Name, "UQ__Gender__72E12F1B6A4B1644").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grade__3214EC27577DF48C");

            entity.ToTable("Grade");

            entity.HasIndex(e => e.Value, "UQ__Grade__40BBEA3ACD0458BB").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<GraduationDiploma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Graduati__3214EC27B5B3EB58");

            entity.ToTable("Graduation_Diploma");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DocumentFk).HasColumnName("Document_FK");
            entity.Property(e => e.Gpa).HasColumnName("GPA");
            entity.Property(e => e.GraduationField)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Graduation_Field");

            entity.HasOne(d => d.DocumentFkNavigation).WithMany(p => p.GraduationDiplomas)
                .HasForeignKey(d => d.DocumentFk)
                .HasConstraintName("FK__Graduatio__Docum__7F2BE32F");
        });

        modelBuilder.Entity<HighSchoolDiploma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__High_Sch__3214EC270F20BCFC");

            entity.ToTable("High_School_Diploma");

            entity.HasIndex(e => e.DiplomaNumber, "UQ__High_Sch__79C41681320CF399").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AcquisitionDate).HasColumnName("Acquisition_Date");
            entity.Property(e => e.AdditionalSubjectResult).HasColumnName("Additional_Subject_Result");
            entity.Property(e => e.BiologyResult).HasColumnName("Biology_Result");
            entity.Property(e => e.DiplomaNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Diploma_Number");
            entity.Property(e => e.DocumentFk).HasColumnName("Document_FK");
            entity.Property(e => e.ForeignAdvancedResult).HasColumnName("Foreign_Advanced_Result");
            entity.Property(e => e.ForeignBasicResult).HasColumnName("Foreign_Basic_Result");
            entity.Property(e => e.MathAdvancedResult).HasColumnName("Math_Advanced_Result");
            entity.Property(e => e.MathBasicResult).HasColumnName("Math_Basic_Result");
            entity.Property(e => e.PolishAdvancedResult).HasColumnName("Polish_Advanced_Result");
            entity.Property(e => e.PolishBasicResult).HasColumnName("Polish_Basic_Result");

            entity.HasOne(d => d.DocumentFkNavigation).WithMany(p => p.HighSchoolDiplomas)
                .HasForeignKey(d => d.DocumentFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKHigh_School_DiplomaDocument");
        });

        modelBuilder.Entity<HighSchoolType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__High_Sch__3214EC27D8591C33");

            entity.ToTable("High_School_Type");

            entity.HasIndex(e => e.Name, "UQ__High_Sch__72E12F1B5D0894CE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<IdentityDocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Identity__3214EC27C04F4206");

            entity.ToTable("Identity_Document_Type");

            entity.HasIndex(e => e.Name, "UQ__Identity__72E12F1B2E08C622").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<LoggedUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logged_U__3214EC271B179053");

            entity.ToTable("Logged_User");

            entity.HasIndex(e => e.Email, "UQ__Logged_U__A9D10534DFB84E88").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountCreationDate).HasColumnName("Account_Creation_Date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OlympiadSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Olympiad__3214EC2716B2389D");

            entity.ToTable("Olympiad_Subject");

            entity.HasIndex(e => e.Name, "UQ__Olympiad__72E12F1BEED3C1AF").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<OlympiadWinnerDiploma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Olympiad__3214EC27874146E6");

            entity.ToTable("Olympiad_Winner_Diploma");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AcquisitionDate).HasColumnName("Acquisition_Date");
            entity.Property(e => e.DocumentFk).HasColumnName("Document_FK");
            entity.Property(e => e.ExpiryDate).HasColumnName("Expiry_Date");
            entity.Property(e => e.OlympiadSubjectFk).HasColumnName("Olympiad_Subject_FK");

            entity.HasOne(d => d.DocumentFkNavigation).WithMany(p => p.OlympiadWinnerDiplomas)
                .HasForeignKey(d => d.DocumentFk)
                .HasConstraintName("FK__Olympiad___Docum__7B5B524B");

            entity.HasOne(d => d.OlympiadSubjectFkNavigation).WithMany(p => p.OlympiadWinnerDiplomas)
                .HasForeignKey(d => d.OlympiadSubjectFk)
                .HasConstraintName("FK__Olympiad___Olymp__7C4F7684");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC277237D7B9");

            entity.ToTable("Question");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AnswerA)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AnswerB)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AnswerC)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AnswerD)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QuestionContent)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Question_Content");
            entity.Property(e => e.QuestionPoolFk).HasColumnName("Question_Pool_FK");

            entity.HasOne(d => d.QuestionPoolFkNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuestionPoolFk)
                .HasConstraintName("FK__Question__Questi__6D0D32F4");
        });

        modelBuilder.Entity<QuestionPool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC27D184514A");

            entity.ToTable("Question_Pool");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UniversityFk).HasColumnName("University_FK");

            entity.HasOne(d => d.UniversityFkNavigation).WithMany(p => p.QuestionPools)
                .HasForeignKey(d => d.UniversityFk)
                .HasConstraintName("FK__Question___Unive__6A30C649");
        });

        modelBuilder.Entity<RankingList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ranking___3214EC27E3EF6B87");

            entity.ToTable("Ranking_List");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Recruitment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recruitm__3214EC27CFAD232E");

            entity.ToTable("Recruitment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApplicationSubmissionDeadline).HasColumnName("Application_Submission_Deadline");
            entity.Property(e => e.DocumentSubmissionDeadline).HasColumnName("Document_Submission_Deadline");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.FeePaymentDeadline).HasColumnName("Fee_Payment_Deadline");
            entity.Property(e => e.FieldOfStudyFk).HasColumnName("Field_Of_Study_FK");
            entity.Property(e => e.PointThreshold).HasColumnName("Point_Threshold");
            entity.Property(e => e.PreviousRoundFk).HasColumnName("Previous_Round_FK");
            entity.Property(e => e.RoundNumber).HasColumnName("Round_Number");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");

            entity.HasOne(d => d.FieldOfStudyFkNavigation).WithMany(p => p.Recruitments)
                .HasForeignKey(d => d.FieldOfStudyFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recruitme__Field__59063A47");

            entity.HasOne(d => d.PreviousRoundFkNavigation).WithMany(p => p.InversePreviousRoundFkNavigation)
                .HasForeignKey(d => d.PreviousRoundFk)
                .HasConstraintName("FK__Recruitme__Previ__59FA5E80");
        });

        modelBuilder.Entity<RecruitmentCriterion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recruitm__3214EC275D1B7301");

            entity.ToTable("Recruitment_Criteria");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Content)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FieldOfStudyFk).HasColumnName("Field_Of_Study_FK");

            entity.HasOne(d => d.FieldOfStudyFkNavigation).WithMany(p => p.RecruitmentCriteria)
                .HasForeignKey(d => d.FieldOfStudyFk)
                .HasConstraintName("FK__Recruitme__Field__6FE99F9F");
        });

        modelBuilder.Entity<SecondDegreeAdmissionExam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Second_D__3214EC27ADE32AC0");

            entity.ToTable("Second_Degree_Admission_Exam");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExamFk).HasColumnName("Exam_FK");

            entity.HasOne(d => d.ExamFkNavigation).WithMany(p => p.SecondDegreeAdmissionExams)
                .HasForeignKey(d => d.ExamFk)
                .HasConstraintName("FK__Second_De__Exam___0C85DE4D");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Speciali__3214EC2707458AD2");

            entity.ToTable("Specialization");

            entity.HasIndex(e => e.SpecializationName, "UQ__Speciali__B6F2CAA656376B6C").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdmissionLimit).HasColumnName("Admission_Limit");
            entity.Property(e => e.FieldOfStudyFk).HasColumnName("Field_Of_Study_FK");
            entity.Property(e => e.SpecializationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Specialization_Name");

            entity.HasOne(d => d.FieldOfStudyFkNavigation).WithMany(p => p.Specializations)
                .HasForeignKey(d => d.FieldOfStudyFk)
                .HasConstraintName("FK__Specializ__Field__73BA3083");
        });

        modelBuilder.Entity<StudyForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Study_Fo__3214EC273FDB504C");

            entity.ToTable("Study_Form");

            entity.HasIndex(e => e.Name, "UQ__Study_Fo__72E12F1B045B9552").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<StudySubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Study_Su__3214EC27F889D934");

            entity.ToTable("Study_Subject");

            entity.HasIndex(e => e.Name, "UQ__Study_Su__72E12F1B26F315B6").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TalentStudyCompletionCertificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Talent_S__3214EC27726D2D3A");

            entity.ToTable("Talent_Study_Completion_Certificate");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AcquisitionDate).HasColumnName("Acquisition_Date");
            entity.Property(e => e.DocumentFk).HasColumnName("Document_FK");
            entity.Property(e => e.StudySubjectFk).HasColumnName("Study_Subject_FK");

            entity.HasOne(d => d.DocumentFkNavigation).WithMany(p => p.TalentStudyCompletionCertificates)
                .HasForeignKey(d => d.DocumentFk)
                .HasConstraintName("FK__Talent_St__Docum__02084FDA");

            entity.HasOne(d => d.StudySubjectFkNavigation).WithMany(p => p.TalentStudyCompletionCertificates)
                .HasForeignKey(d => d.StudySubjectFk)
                .HasConstraintName("FK__Talent_St__Study__02FC7413");
        });

        modelBuilder.Entity<University>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Universi__3214EC2716CCE655");

            entity.ToTable("University");

            entity.HasIndex(e => e.Name, "UQ__Universi__737584F6CE7182A3").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecruitmentPolicies)
                .HasColumnType("text")
                .HasColumnName("Recruitment_Policies");
            entity.Property(e => e.Rector)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
