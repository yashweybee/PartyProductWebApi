using System.ComponentModel.DataAnnotations;

namespace PartyProductWebApi.DTOs
{
    public class AssignPartyCreationDTO
    {
        [Required]
        public int PartyId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
