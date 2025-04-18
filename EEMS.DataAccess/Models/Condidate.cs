using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.DataAccess.Models
{
    public class Condidate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Training { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string BirthLocation { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string FamilySituation { get; set; }

        [Required]
        public int Gender { get; set; }

        public string? EssentialTraining { get; set; }

        public DateTime InterviewDate { get; set; }

        public string? LanguagesSpoken { get; set; }

        public int? Experience { get; set; }

        [Required]
        public string Residence { get; set; }

      
        public bool IsArchived { get; set; }
    }
}
