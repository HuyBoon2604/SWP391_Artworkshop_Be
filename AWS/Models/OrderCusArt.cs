using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class OrderCusArt
    {
        public OrderCusArt()
        {
            PaymentCusArts = new HashSet<PaymentCusArt>();
        }

        public string OrderCusArtId { get; set; } = null!;
        public string? OrderRequireId { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Status { get; set; }
        public decimal? Total { get; set; }

        public virtual OrderRequire? OrderRequire { get; set; }
        public virtual ICollection<PaymentCusArt> PaymentCusArts { get; set; }
    }
}
