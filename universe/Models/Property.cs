using System;
using System.Collections.Generic;

namespace universe.Models
{
    public partial class Property
    {
        public int PropertyId { get; set; }
        public string PName { get; set; } = null!;
        public DateTime? BStart { get; set; }
        public decimal BCost { get; set; }
        public int? BCostYear { get; set; }
        public decimal? BCostAfter { get; set; }
        public int BPeriod { get; set; }
        public int BAudienceId { get; set; }

        public virtual Audience BAudience { get; set; } = null!;
    }
}
