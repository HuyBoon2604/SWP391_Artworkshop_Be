using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class PaymentCusArt
    {
        public string PaymentCusArtId { get; set; } = null!;
        public string? OrderCusArtId { get; set; }
        public bool? Status { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? TransctionCode { get; set; }

        public virtual OrderCusArt? OrderCusArt { get; set; }
    }
}
