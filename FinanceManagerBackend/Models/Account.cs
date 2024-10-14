using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace FinanceManagerBackend.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; } = null!;

        public int Color { get; set; }

        [JsonIgnore]
        public List<User>? Users { get; set; }
    }
}
