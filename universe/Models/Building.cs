using System;
using System.Collections.Generic;

namespace universe.Models
{
    public partial class Building
    {
        public Building()
        {
            Audiences = new HashSet<Audience>();
        }

        public int BuildId { get; set; }
        public int BKadastr { get; set; }
        public string BName { get; set; } = null!;
        public int BLand { get; set; }
        public int BYear { get; set; }
        public string BMaterial { get; set; } = null!;
        public string BAdress { get; set; } = null!;
        public int BWear { get; set; }
        public byte[] BPicture { get; set; } = null!;

        public virtual ICollection<Audience> Audiences { get; set; }
    }
}
