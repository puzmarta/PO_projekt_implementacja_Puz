using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PO_projekt_implementacja_Puz.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicTitle> AcademicTitles { get; set; }

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Academic__3214EC276FF4847A");

            entity.ToTable("Academic_Title");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC27444E1FEB");

            entity.ToTable("Application");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApplicationIdentifier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Application_Identifier");
            entity.Property(e => e.ApplicationStatusFk).HasColumnName("Application_Status_FK");
            entity.Property(e => e.CandidateFk).HasColumnName("Candidate_FK");
            entity.Property(e => e.HighSchoolTranscriptFk).HasColumnName("High_School_Transcript_FK");
            entity.Property(e => e.RecruitmentFk).HasColumnName("Recruitment_FK");
            entity.Property(e => e.RecruitmentIndex).HasColumnName("Recruitment_Index");

            entity.HasOne(d => d.ApplicationStatusFkNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicationStatusFk)
                .HasConstraintName("FK__Applicati__Appli__4F7CD00D");

            entity.HasOne(d => d.CandidateFkNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.CandidateFk)
                .HasConstraintName("FK__Applicati__Candi__4D94879B");

            entity.HasOne(d => d.HighSchoolTranscriptFkNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.HighSchoolTranscriptFk)
                .HasConstraintName("FKApplicationHigh_School_Diploma");

            entity.HasOne(d => d.RecruitmentFkNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.RecruitmentFk)
                .HasConstraintName("FK__Applicati__Recru__4E88ABD4");
        });

        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC2749F9635D");

            entity.ToTable("Application_Status");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Candidat__3214EC275657CE90");

            entity.ToTable("Candidate");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CertificateNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Certificate_Number");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_of_Birth");
            entity.Property(e => e.DateOfIssuingCertificate).HasColumnName("Date_of_Issuing_Certificate");
            entity.Property(e => e.GenderFk).HasColumnName("Gender_FK");
            entity.Property(e => e.HighSchoolCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("High_School_City");
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
                .HasConstraintName("FK__Candidate__Gende__440B1D61");

            entity.HasOne(d => d.HighSchoolTypeFkNavigation).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.HighSchoolTypeFk)
                .HasConstraintName("FK__Candidate__High___46E78A0C");

            entity.HasOne(d => d.IdentityDocumentTypeFkNavigation).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.IdentityDocumentTypeFk)
                .HasConstraintName("FK__Candidate__Ident__45F365D3");

            entity.HasOne(d => d.LoggedUserFkNavigation).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.LoggedUserFk)
                .HasConstraintName("FK__Candidate__Logge__44FF419A");

            entity.HasMany(d => d.RankingListFks).WithMany(p => p.CandidateFks)
                .UsingEntity<Dictionary<string, object>>(
                    "CandidateRankingList",
                    r => r.HasOne<RankingList>().WithMany()
                        .HasForeignKey("RankingListFk")
                        .HasConstraintName("FK__Candidate__Ranki__7C4F7684"),
                    l => l.HasOne<Candidate>().WithMany()
                        .HasForeignKey("CandidateFk")
                        .HasConstraintName("FK__Candidate__Candi__7B5B524B"),
                    j =>
                    {
                        j.HasKey("CandidateFk", "RankingListFk").HasName("PK__Candidat__66485A3220590161");
                        j.ToTable("Candidate_Ranking_List");
                        j.IndexerProperty<int>("CandidateFk").HasColumnName("Candidate_FK");
                        j.IndexerProperty<int>("RankingListFk").HasColumnName("Ranking_List_FK");
                    });
        });

        modelBuilder.Entity<DegreeLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Degree_L__3214EC2741A60A89");

            entity.ToTable("Degree_Level");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC2729AC1D93");

            entity.ToTable("Document");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApplicationFk).HasColumnName("Application_FK");
            entity.Property(e => e.CreationDate).HasColumnName("Creation_Date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.ApplicationFkNavigation).WithMany(p => p.Documents)
                .HasForeignKey(d => d.ApplicationFk)
                .HasConstraintName("FK__Document__Applic__52593CB8");
        });

        modelBuilder.Entity<DrawingAdmissionExam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drawing___3214EC273BBB8BF8");

            entity.ToTable("Drawing_Admission_Exam");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExamFk).HasColumnName("Exam_FK");

            entity.HasOne(d => d.ExamFkNavigation).WithMany(p => p.DrawingAdmissionExams)
                .HasForeignKey(d => d.ExamFk)
                .HasConstraintName("FK__Drawing_A__Exam___75A278F5");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC277FAB16AC");

            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LoggedUserFk).HasColumnName("Logged_User_FK");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.LoggedUserFkNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.LoggedUserFk)
                .HasConstraintName("FK__Employee__Logged__60A75C0F");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exam__3214EC273198F873");

            entity.ToTable("Exam");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GradeFk).HasColumnName("Grade_FK");

            entity.HasOne(d => d.GradeFkNavigation).WithMany(p => p.Exams)
                .HasForeignKey(d => d.GradeFk)
                .HasConstraintName("FK__Exam__Grade_FK__72C60C4A");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Faculty__3214EC2765B2B97E");

            entity.ToTable("Faculty");

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
                .HasConstraintName("FK__Faculty__Univers__398D8EEE");
        });

        modelBuilder.Entity<FieldOfStudy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Field_Of__3214EC270E77AEC1");

            entity.ToTable("Field_Of_Study");

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
                .HasConstraintName("FK__Field_Of___Acade__3F466844");

            entity.HasOne(d => d.DegreeLevelFkNavigation).WithMany(p => p.FieldOfStudies)
                .HasForeignKey(d => d.DegreeLevelFk)
                .HasConstraintName("FK__Field_Of___Degre__3E52440B");

            entity.HasOne(d => d.FacultyFkNavigation).WithMany(p => p.FieldOfStudies)
                .HasForeignKey(d => d.FacultyFk)
                .HasConstraintName("FK__Field_Of___Facul__3C69FB99");

            entity.HasOne(d => d.StudyFormFkNavigation).WithMany(p => p.FieldOfStudies)
                .HasForeignKey(d => d.StudyFormFk)
                .HasConstraintName("FK__Field_Of___Study__3D5E1FD2");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gender__3214EC278B316A47");

            entity.ToTable("Gender");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grade__3214EC276557CABA");

            entity.ToTable("Grade");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<GraduationDiploma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Graduati__3214EC27EF6E1BAB");

            entity.ToTable("Graduation_Diploma");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DocumentFk).HasColumnName("Document_FK");
            entity.Property(e => e.GraduationField)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Graduation_Field");
            entity.Property(e => e.WeightedAverage).HasColumnName("Weighted_Average");

            entity.HasOne(d => d.DocumentFkNavigation).WithMany(p => p.GraduationDiplomas)
                .HasForeignKey(d => d.DocumentFk)
                .HasConstraintName("FK__Graduatio__Docum__693CA210");
        });

        modelBuilder.Entity<HighSchoolDiploma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__High_Sch__3214EC2773EBFD6B");

            entity.ToTable("High_School_Diploma");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AcquisitionDate).HasColumnName("Acquisition_Date");
            entity.Property(e => e.AdditionalSubjectResult).HasColumnName("Additional_Subject_Result");
            entity.Property(e => e.BiologyResult).HasColumnName("Biology_Result");
            entity.Property(e => e.DocumentFk).HasColumnName("Document_FK");
            entity.Property(e => e.ForeignAdvancedResult).HasColumnName("Foreign_Advanced_Result");
            entity.Property(e => e.ForeignBasicResult).HasColumnName("Foreign_Basic_Result");
            entity.Property(e => e.MathAdvancedResult).HasColumnName("Math_Advanced_Result");
            entity.Property(e => e.MathBasicResult).HasColumnName("Math_Basic_Result");
            entity.Property(e => e.PolishAdvancedResult).HasColumnName("Polish_Advanced_Result");
            entity.Property(e => e.PolishBasicResult).HasColumnName("Polish_Basic_Result");

            entity.HasOne(d => d.DocumentFkNavigation).WithMany(p => p.HighSchoolDiplomas)
                .HasForeignKey(d => d.DocumentFk)
                .HasConstraintName("FK__High_Scho__Docum__6FE99F9F");
        });

        modelBuilder.Entity<HighSchoolType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__High_Sch__3214EC270FF75157");

            entity.ToTable("High_School_Type");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<IdentityDocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Identity__3214EC276B4281B8");

            entity.ToTable("Identity_Document_Type");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<LoggedUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logged_U__3214EC2787F16029");

            entity.ToTable("Logged_User");

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
            entity.HasKey(e => e.Id).HasName("PK__Olympiad__3214EC27652DD439");

            entity.ToTable("Olympiad_Subject");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<OlympiadWinnerDiploma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Olympiad__3214EC27E6485FF2");

            entity.ToTable("Olympiad_Winner_Diploma");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AcquisitionDate).HasColumnName("Acquisition_Date");
            entity.Property(e => e.DocumentFk).HasColumnName("Document_FK");
            entity.Property(e => e.ExpiryDate).HasColumnName("Expiry_Date");
            entity.Property(e => e.OlympiadSubjectFk).HasColumnName("Olympiad_Subject_FK");

            entity.HasOne(d => d.DocumentFkNavigation).WithMany(p => p.OlympiadWinnerDiplomas)
                .HasForeignKey(d => d.DocumentFk)
                .HasConstraintName("FK__Olympiad___Docum__656C112C");

            entity.HasOne(d => d.OlympiadSubjectFkNavigation).WithMany(p => p.OlympiadWinnerDiplomas)
                .HasForeignKey(d => d.OlympiadSubjectFk)
                .HasConstraintName("FK__Olympiad___Olymp__66603565");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK___Questio__3214EC27F32ADC27");

            entity.ToTable("_Question");

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
                .HasConstraintName("FK___Question__Quest__5812160E");
        });

        modelBuilder.Entity<QuestionPool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC27E7970B92");

            entity.ToTable("Question_Pool");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UniversityFk).HasColumnName("University_FK");

            entity.HasOne(d => d.UniversityFkNavigation).WithMany(p => p.QuestionPools)
                .HasForeignKey(d => d.UniversityFk)
                .HasConstraintName("FK__Question___Unive__5535A963");
        });

        modelBuilder.Entity<RankingList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ranking___3214EC275A559E1F");

            entity.ToTable("Ranking_List");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Recruitment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recruitm__3214EC2705DD4FFC");

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
                .HasConstraintName("FK__Recruitme__Field__49C3F6B7");

            entity.HasOne(d => d.PreviousRoundFkNavigation).WithMany(p => p.InversePreviousRoundFkNavigation)
                .HasForeignKey(d => d.PreviousRoundFk)
                .HasConstraintName("FK__Recruitme__Previ__4AB81AF0");
        });

        modelBuilder.Entity<RecruitmentCriterion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recruitm__3214EC270DDFF79E");

            entity.ToTable("Recruitment_Criteria");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Content)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FieldOfStudyFk).HasColumnName("Field_Of_Study_FK");

            entity.HasOne(d => d.FieldOfStudyFkNavigation).WithMany(p => p.RecruitmentCriteria)
                .HasForeignKey(d => d.FieldOfStudyFk)
                .HasConstraintName("FK__Recruitme__Field__5AEE82B9");
        });

        modelBuilder.Entity<SecondDegreeAdmissionExam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Second_D__3214EC270D8C0C08");

            entity.ToTable("Second_Degree_Admission_Exam");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExamFk).HasColumnName("Exam_FK");

            entity.HasOne(d => d.ExamFkNavigation).WithMany(p => p.SecondDegreeAdmissionExams)
                .HasForeignKey(d => d.ExamFk)
                .HasConstraintName("FK__Second_De__Exam___787EE5A0");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Speciali__3214EC27CDACFDCE");

            entity.ToTable("Specialization");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdmissionLimit).HasColumnName("Admission_Limit");
            entity.Property(e => e.FieldOfStudyFk).HasColumnName("Field_Of_Study_FK");
            entity.Property(e => e.SpecializationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Specialization_Name");

            entity.HasOne(d => d.FieldOfStudyFkNavigation).WithMany(p => p.Specializations)
                .HasForeignKey(d => d.FieldOfStudyFk)
                .HasConstraintName("FK__Specializ__Field__5DCAEF64");
        });

        modelBuilder.Entity<StudyForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Study_Fo__3214EC276F5784FD");

            entity.ToTable("Study_Form");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<StudySubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Study_Su__3214EC2753B8CB74");

            entity.ToTable("Study_Subject");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TalentStudyCompletionCertificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Talent_S__3214EC272C6096A8");

            entity.ToTable("Talent_Study_Completion_Certificate");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AcquisitionDate).HasColumnName("Acquisition_Date");
            entity.Property(e => e.DocumentFk).HasColumnName("Document_FK");
            entity.Property(e => e.StudySubjectFk).HasColumnName("Study_Subject_FK");

            entity.HasOne(d => d.DocumentFkNavigation).WithMany(p => p.TalentStudyCompletionCertificates)
                .HasForeignKey(d => d.DocumentFk)
                .HasConstraintName("FK__Talent_St__Docum__6C190EBB");

            entity.HasOne(d => d.StudySubjectFkNavigation).WithMany(p => p.TalentStudyCompletionCertificates)
                .HasForeignKey(d => d.StudySubjectFk)
                .HasConstraintName("FK__Talent_St__Study__6D0D32F4");
        });

        modelBuilder.Entity<University>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Universi__3214EC277BB679D3");

            entity.ToTable("University");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
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
