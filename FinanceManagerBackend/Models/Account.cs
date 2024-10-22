﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace FinanceManagerBackend.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }  // Unique identifier for the Account

        [MaxLength(30)]
        public string Name { get; set; } = null!;  // Name of the Account (max. 30 characters)

        [MaxLength(200)]
        public string Description { get; set; }  // Description of the Account (optional, max. 200 characters)

        [MaxLength(256)]
        public string EMail { get; set; } = null!;  // Email address of the Account (max. 256 characters)

        [JsonIgnore]
        public List<User>? Users { get; set; }  // Associated Users of the Account (Navigation Property)
    }
}
