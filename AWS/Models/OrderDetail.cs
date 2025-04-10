using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class OrderDetail
    {
        public string OrderId { get; set; } = null!;
        public string ArtworkId { get; set; } = null!;
        public bool? Status { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual Artwork Artwork { get; set; } = null!;
        public virtual Ordertb Order { get; set; } = null!;
    }
}
