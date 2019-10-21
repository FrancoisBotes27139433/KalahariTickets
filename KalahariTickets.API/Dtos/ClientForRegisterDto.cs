using System.ComponentModel.DataAnnotations;

namespace KalahariTickets.API.Dtos
{
    public class ClientForRegisterDto
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}