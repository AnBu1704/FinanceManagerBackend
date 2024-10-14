using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinanceManagerBackend.Models
{
    public class AccountDTO
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; } = null!;

        public int Color { get; set; }

        [JsonIgnore]
        public UserDTO Users { get; set; }
    }
}
