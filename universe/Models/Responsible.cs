using System;
using System.Collections.Generic;

namespace universe.Models
{
    public partial class Responsible
    {
        public Responsible()
        {
            Audiences = new HashSet<Audience>();
        }

        public int ResponsibleId { get; set; }
        public string RAdressResp { get; set; } = null!;
        public int RExperiense { get; set; }
        public string? RName { get; set; }

        public virtual ICollection<Audience> Audiences { get; set; }
    }
}
