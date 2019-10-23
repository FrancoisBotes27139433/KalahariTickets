using System.ComponentModel.DataAnnotations;

namespace KalahariTickets.API.Dtos
{
    public class TechnitionForRegisterDto
    {
       // [Required]
        public string FirstName { get; set; }

        //[Required]
        public string LastName { get; set; }

        
        public int MonthlySalary { get; set; }

        public int Age { get; set; }

    }
}