using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class OrderRequire
    {
        public OrderRequire()
        {
            OrderCusArts = new HashSet<OrderCusArt>();
        }

        public string OrderRequireId { get; set; } = null!;
        public string? ArtworkCustomeId { get; set; }
        public string? UserId { get; set; }
        public bool? Status { get; set; }

        public virtual ArtworkCustome? ArtworkCustome { get; set; }
        public virtual Usertb? User { get; set; }
        public virtual ICollection<OrderCusArt> OrderCusArts { get; set; }
    }
}
