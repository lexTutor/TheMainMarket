using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheMainMarket.Models
{
    public class Token: BaseEntity, IBase
    {
        [Key]
        public string RefreshToken { get; set; }

        public string JwtId { get; set; }

        public bool Invalidated { get; set; }

        public string UserId { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow.AddMonths(3);

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
