using System.ComponentModel.DataAnnotations;

namespace RichestHumansAlive.Models
{
    public class RichHuman
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [StringLength(60, MinimumLength = 5)]
        [Required]
        public string TheirExpertise { get; set; } = string.Empty;

        [StringLength(30, MinimumLength = 5)]
        [Required]
        public string NetWorth { get; set; } = string.Empty;

        [Range(5, 100)]
        public int Age { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [Required]
        public string Nationality { get; set; } = string.Empty; 

        [StringLength(30, MinimumLength = 5)]
        [Required]

        public string Gender { get; set; } = string.Empty;

        [Range(1, 100)]
        public int Rank { get; set; }

    }
}