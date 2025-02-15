﻿using EEMS.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Training { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthLocation { get; set; }
        public string Address { get; set; }
        public string FamilySituation { get; set; }
        public DateTime RecruitmentDate { get; set; }
        public Gender Gender { get; set; }
        public string? EssentialTraining { get; set; }
        public string? LanguagesSpoken { get; set; }
        public int? Experience { get; set; }
        public string Residence { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        public int? JobNatureId { get; set; }
        public JobNature JobNature { get; set; }

        public ICollection<EmployeeDrivingLicense> EmployeeDrivingLicenses { get; set; }
        public ICollection<Absence> Absences { get; set; }

    }
}
