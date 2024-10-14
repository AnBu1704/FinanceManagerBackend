using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinanceManagerBackend.Models
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; } = null!;

        public List<AccountDTO> Accounts { get; set; }
    }
}
