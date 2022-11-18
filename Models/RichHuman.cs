using System.ComponentModel.DataAnnotations;

namespace RichestHumansAlive.Models
{
    public class RichHuman
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string TheirExpertise { get; set; } = string.Empty;
        public string NetWorth { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Nationality { get; set; } = string.Empty; 

        public string Gender { get; set; } = string.Empty;

        public int Rank { get; set; }

    }
}