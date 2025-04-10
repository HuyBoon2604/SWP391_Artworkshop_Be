using System;
using System.Collections.Generic;

namespace AWS.Models
{
    public partial class ArtworkCustome
    {
        public ArtworkCustome()
        {
            OrderRequires = new HashSet<OrderRequire>();
        }

        public string ArtworkCustomeId { get; set; } = null!;
        public string? UserId { get; set; }
        public bool? Status { get; set; }
        public string? DeadlineDate { get; set; }
        public string? Description { get; set; }
        public DateTime? Time { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }

        public virtual Usertb? User { get; set; }
        public virtual ICollection<OrderRequire> OrderRequires { get; set; }
    }
}
