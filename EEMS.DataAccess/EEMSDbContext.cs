﻿using EEMS.Utilities.Enums;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EEMS.DataAccess
{
    public class EEMSDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Condidate> condidates { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<AbsenceType> AbsenceTypes { get; set; }
        public DbSet<DrivingLicenseType> DrivingLicenseTypes { get; set; }
        public DbSet<EmployeeDrivingLicense> EmployeeDrivingLicenses { get; set; }
        public DbSet<JobNature> JobNatures { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<EmployeeTraining> EmployeesTraining { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Diploma> Diplomas { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Sanction> Sanctions { get; set; }

        public EEMSDbContext() { }

        public EEMSDbContext(DbContextOptions<EEMSDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigHelper.GetConnectionString());
            }
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One to Many: Department -> Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            // One to Many: Employee -> Absence
            modelBuilder.Entity<Absence>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Absences)
                .HasForeignKey(a => a.EmployeeId);

            // One to Many: AbsenceType -> Absence
            modelBuilder.Entity<Absence>()
                .HasOne(a => a.AbsenceType)
                .WithMany(ab => ab.Absences)
                .HasForeignKey(a => a.AbsenceTypeId);

            // Many to Many: Employee -> EmployeeDrivingLicense
            modelBuilder.Entity<EmployeeDrivingLicense>()
                .HasKey(ed => new { ed.EmployeeId, ed.DrivingLicenseTypeId });

            modelBuilder.Entity<EmployeeDrivingLicense>()
                .HasOne(edl => edl.Employee)
                .WithMany(e => e.EmployeeDrivingLicenses)
                .HasForeignKey(edl => edl.EmployeeId);

            modelBuilder.Entity<EmployeeDrivingLicense>()
                .HasOne(edl => edl.DrivingLicenseType)
                .WithMany(dlt => dlt.EmployeeDrivingLicenses)
                .HasForeignKey(edl => edl.DrivingLicenseTypeId);

            // One to Many: JobNature -> Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.JobNature)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobNatureId);

            // One to Many: Employee -> Vacation
            modelBuilder.Entity<Vacation>()
                .HasOne(v => v.Employee)
                .WithMany(e => e.Vacations)
                .HasForeignKey(v => v.EmployeeId);

            modelBuilder.Entity<Vacation>()
                .Property(v => v.StartDate)
                .HasColumnType("date");

            //One to One: Employee->Leave
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Leave)
                .WithOne(l => l.Employee)
                .HasForeignKey<Employee>(e => e.LeaveId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // Many to Many: Employee -> EmployeeTraining
            modelBuilder.Entity<EmployeeTraining>()
                .HasKey(et => new { et.EmployeeId, et.TrainingId });

            modelBuilder.Entity<EmployeeTraining>()
                .HasOne(et => et.Employee)
                .WithMany(e => e.EmployeesTraining)
                .HasForeignKey(et => et.EmployeeId);

            modelBuilder.Entity<EmployeeTraining>()
                .HasOne(et => et.Training)
                .WithMany(t => t.EmployeesTraining)
                .HasForeignKey(et => et.TrainingId);

            modelBuilder.Entity<Training>()
                .Property(t => t.StartDate)
                .HasColumnType("date");

            // One to Many: Employee -> Diploma
            modelBuilder.Entity<Diploma>()
                .HasOne(d => d.Employee)
                .WithMany(e => e.Diplomas)
                .HasForeignKey(d => d.EmployeeId);

            // One to Many: Training -> Diploma
            modelBuilder.Entity<Diploma>()
                .HasOne(d => d.Training)
                .WithMany(t => t.Diplomas)
                .HasForeignKey(d => d.TrainingId);

            modelBuilder.Entity<Diploma>()
                .Property(d => d.DateIssued)
                .HasColumnType("date");

            // One to Many: Employee -> Senction
            modelBuilder.Entity<Sanction>()
                .HasOne(s => s.Employee)
                .WithMany(e => e.Sanctions)
                .HasForeignKey(s => s.EmployeeId);

            modelBuilder.Entity<Sanction>()
                .Property(s => s.DateHappened)
                .HasColumnType("date");


            // Data seeding

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Human Resources" },
                new Department { Id = 2, Name = "Budget and Accounting" },
                new Department { Id = 3, Name = "General Administration" }
                );

            //modelBuilder.Entity<Project>().HasData(
            //    new Project { Id = 1, Name = "Gas maintanance", Place = "Tamanraset" },
            //    new Project { Id = 2, Name = "Gas Finding", Place = "Ain Salah" },
            //    new Project { Id = 3, Name = "Gas Tube Manufacture", Place = "Djanat" }
            //    );

            modelBuilder.Entity<JobNature>().HasData(
                new JobNature { Id = 1, Name = "Full-time Work" },
                new JobNature { Id = 2, Name = "Part-time Work" },
                new JobNature { Id = 3, Name = "Temporary Work" }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Phone = "123-456-7890",
                    JobTitle = "Software Engineer",
                    Email = "john.doe@example.com",
                    Training = "C#, .NET, SQL",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    BirthLocation = "New York, USA",
                    Address = "123 Main St, New York, USA",
                    FamilySituation = "Single",
                    RecruitmentDate = new DateTime(2020, 1, 10),
                    Gender = 0,
                    Residence = "New York, USA",
                    IsActive = true,
                    IsDeleted = false,
                    DepartmentId = 1,
                    JobNatureId = 1
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Phone = "987-654-3210",
                    JobTitle = "Project Manager",
                    Email = "jane.smith@example.com",
                    Training = "PMP, Agile, Scrum",
                    DateOfBirth = new DateTime(1985, 8, 20),
                    BirthLocation = "Los Angeles, USA",
                    Address = "456 Elm St, Los Angeles, USA",
                    FamilySituation = "Married",
                    RecruitmentDate = new DateTime(2018, 3, 22),
                    Gender = 1,
                    Residence = "Los Angeles, USA",
                    IsActive = true,
                    IsDeleted = false,
                    DepartmentId = 2,
                    JobNatureId = 2
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Phone = "555-123-4567",
                    JobTitle = "QA Engineer",
                    Email = "alice.johnson@example.com",
                    Training = "Selenium, Manual Testing",
                    DateOfBirth = new DateTime(1992, 12, 5),
                    BirthLocation = "Chicago, USA",
                    Address = "789 Oak St, Chicago, USA",
                    FamilySituation = "Single",
                    RecruitmentDate = new DateTime(2021, 7, 15),
                    Gender = 1,
                    Residence = "Chicago, USA",
                    IsActive = true,
                    IsDeleted = false,
                    DepartmentId = 1,
                    JobNatureId = 3
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Bob",
                    LastName = "Brown",
                    Phone = "444-555-6666",
                    JobTitle = "DevOps Engineer",
                    Email = "bob.brown@example.com",
                    Training = "Docker, Kubernetes, Azure",
                    DateOfBirth = new DateTime(1988, 3, 25),
                    BirthLocation = "Houston, USA",
                    Address = "321 Pine St, Houston, USA",
                    FamilySituation = "Married",
                    RecruitmentDate = new DateTime(2019, 9, 30),
                    Gender = 1,
                    Residence = "Houston, USA",
                    IsActive = true,
                    IsDeleted = false,
                    DepartmentId = 3,
                    JobNatureId = 1
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Charlie",
                    LastName = "Davis",
                    Phone = "777-888-9999",
                    JobTitle = "UI/UX Designer",
                    Email = "charlie.davis@example.com",
                    Training = "Figma, Adobe XD, Sketch",
                    DateOfBirth = new DateTime(1995, 7, 10),
                    BirthLocation = "Miami, USA",
                    Address = "654 Beach St, Miami, USA",
                    FamilySituation = "Single",
                    RecruitmentDate = new DateTime(2022, 2, 5),
                    Gender = 1,
                    Residence = "Miami, USA",
                    IsActive = true,
                    IsDeleted = false,
                    DepartmentId = 2,
                    JobNatureId = 3
                });



        }
    }
}
