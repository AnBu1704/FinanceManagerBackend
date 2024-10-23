using System.ComponentModel.DataAnnotations;

namespace FinanceManagerBackend.DTOs
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }  // Unique identifier for the User

        [MaxLength(30)]
        public string Name { get; set; } = null!;  // Name of the User (max. 30 characters)

        public int Color { get; set; }  // Color value for the User (e.g., as a hex code)
    }
}
