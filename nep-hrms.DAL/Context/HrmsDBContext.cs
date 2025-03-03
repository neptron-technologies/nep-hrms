using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Security;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace nep_hrms.Server.nep_hrms.DAL;

public partial class HrmsDBContext : DbContext
{
   

    public HrmsDBContext(DbContextOptions<HrmsDBContext> options): base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<DesignationHistory> DesignationHistories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeCertification> EmployeeCertifications { get; set; }

    public virtual DbSet<EmployeeContactDetail> EmployeeContactDetails { get; set; }

    public virtual DbSet<EmployeeGrade> EmployeeGrades { get; set; }

    public virtual DbSet<EmployeeJobHistory> EmployeeJobHistories { get; set; }

    public virtual DbSet<EmployeeKyc> EmployeeKycs { get; set; }

    public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<LoginLog> LoginLogs { get; set; }

    public virtual DbSet<MasterKyc> MasterKycs { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=192.168.0.101,1433;Initial Catalog=np-hrms;Persist Security Info=True;User ID=npadmin;Password=admin123;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attendan__3213E83F26E78965");

            entity.ToTable("Attendance");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AttendanceDate).HasColumnName("attendance_date");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.HoursFilled).HasColumnName("hours_filled");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("remarks");
            entity.Property(e => e.ReviewedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reviewed_by");
            entity.Property(e => e.ReviewedDt)
                .HasColumnType("datetime")
                .HasColumnName("reviewed_dt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");

            entity.HasOne(d => d.Emp).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Emp");
        });

        modelBuilder.Entity<Designation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Designat__3213E83F90A91C5B");

            entity.ToTable("Designation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.DesigName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("desig_name");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");
        });

        modelBuilder.Entity<DesignationHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Designat__3213E83F0D7321C0");

            entity.ToTable("DesignationHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.DesignationId).HasColumnName("designation_id");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.EndDt).HasColumnName("end_dt");
            entity.Property(e => e.StartDt).HasColumnName("start_dt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");

            entity.HasOne(d => d.Designation).WithMany(p => p.DesignationHistories)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("FK_EmpDesignation");

            entity.HasOne(d => d.Emp).WithMany(p => p.DesignationHistories)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Empdes_history");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F493810B3");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.CompanyEmail, "UQ__Employee__7C4661D143DC0782").IsUnique();

            entity.HasIndex(e => e.EmpCode, "UQ__Employee__B1056ABCA966495B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.BaseLoc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("base_loc");
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("blood_group");
            entity.Property(e => e.CompanyEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("company_email");
            entity.Property(e => e.Contractor)
                .HasDefaultValue(false)
                .HasColumnName("contractor");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("designation");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Doj).HasColumnName("doj");
            entity.Property(e => e.EmpCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("emp_code");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.Grade)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("grade");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lname");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");

            entity.HasOne(d => d.GradeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Empgrade");
        });

        modelBuilder.Entity<EmployeeCertification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F6A0C8F95");

            entity.ToTable("EmployeeCertification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CertificateId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("certificate_id");
            entity.Property(e => e.CertificateName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("certificate_name");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.IssuedOn)
                .HasColumnType("datetime")
                .HasColumnName("issued_on");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");
            entity.Property(e => e.ValidUpto)
                .HasColumnType("datetime")
                .HasColumnName("valid_upto");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeCertifications)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Empcertification");
        });

        modelBuilder.Entity<EmployeeContactDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F270EEA55");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.Mobile)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.PinCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pin_code");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeContactDetails)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Empcontact");
        });

        modelBuilder.Entity<EmployeeGrade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83FDC40A79C");

            entity.ToTable("EmployeeGrade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Grade)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("grade");
            entity.Property(e => e.Remarks)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("remarks");
        });

        modelBuilder.Entity<EmployeeJobHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F5001B7DB");

            entity.ToTable("EmployeeJobHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.EndDt).HasColumnName("end_dt");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("job_title");
            entity.Property(e => e.Loc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("loc");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.StartDt).HasColumnName("start_dt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeJobHistories)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Empjobhistory");
        });

        modelBuilder.Entity<EmployeeKyc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83FA2085E52");

            entity.ToTable("EmployeeKYC");

            entity.HasIndex(e => e.Passport, "UQ__Employee__5E2A085758A5A782").IsUnique();

            entity.HasIndex(e => e.NationalId, "UQ__Employee__9560E95DCD05F911").IsUnique();

            entity.HasIndex(e => e.VoterId, "UQ__Employee__B795031258A22A34").IsUnique();

            entity.HasIndex(e => e.DrivingLicense, "UQ__Employee__CF3263C4264722A3").IsUnique();

            entity.HasIndex(e => e.Pancard, "UQ__Employee__CF5A5D536CE5057C").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.DrivingLicense)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("driving_license");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.NationalId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("national_id");
            entity.Property(e => e.Pancard)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pancard");
            entity.Property(e => e.Passport)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("passport");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");
            entity.Property(e => e.VoterId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("voter_id");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeKycs)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Empkyc");
        });

        modelBuilder.Entity<EmployeeSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83FEEAC91DB");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.Skills)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("skills");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeSkills)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Empskills");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logs__3213E83F744634BD");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LogDateTime)
                .HasColumnType("datetime")
                .HasColumnName("log_date_time");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("remarks");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_User_Logs");
        });

        modelBuilder.Entity<LoginLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LoginLog__3213E83FD00ACF50");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.LoginTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("login_time");
            entity.Property(e => e.LogoutTime)
                .HasColumnType("datetime")
                .HasColumnName("logout_time");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");

            entity.HasOne(d => d.Emp).WithMany(p => p.LoginLogs)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_Emploginglogs");
        });

        modelBuilder.Entity<MasterKyc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MasterKY__3213E83F8817684F");

            entity.ToTable("MasterKYC");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.EmpkycId).HasColumnName("empkyc_id");
            entity.Property(e => e.KycType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("kyc_type");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");
            entity.Property(e => e.VerifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("verified_by");

            entity.HasOne(d => d.Empkyc).WithMany(p => p.MasterKycs)
                .HasForeignKey(d => d.EmpkycId)
                .HasConstraintName("FK_master_employee");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3213E83FECFC3E9A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.PermissionType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("permission_type");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3213E83FD80EEB7F");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role_name");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolePerm__3213E83FDC2FE512");

            entity.ToTable("RolePermission");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK_permissions");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_role_permission");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F119926BB");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Emp).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_users_emp");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3213E83FD79ACC8F");

            entity.ToTable("UserRole");

            entity.HasIndex(e => e.RoleId, "UQ__UserRole__760965CD01A2E69E").IsUnique();

            entity.HasIndex(e => e.UserId, "UQ__UserRole__B9BE370EC7B31193").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_dt");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDt)
                .HasColumnType("datetime")
                .HasColumnName("updated_dt");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithOne(p => p.UserRole)
                .HasForeignKey<UserRole>(d => d.RoleId)
                .HasConstraintName("FK_roles");

            //entity.HasOne(d => d.User).WithOne(p => p.UserRole)
            //    .HasForeignKey<UserRole>(d => d.UserId)
            //    .HasConstraintName("FK_users_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}