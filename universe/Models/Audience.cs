using System;
using System.Collections.Generic;

namespace universe.Models
{
    public partial class Audience
    {
        public Audience()
        {
            Properties = new HashSet<Property>();
        }

        public int AudienceId { get; set; }
        public int ASquare { get; set; }
        public int AWindows { get; set; }
        public int AHeating { get; set; }
        public string ATarget { get; set; } = null!;
        public int AResponsibleId { get; set; }
        public int ADepartmentId { get; set; }
        public int ABuildId { get; set; }

        public virtual Building ABuild { get; set; } = null!;
        public virtual Department ADepartment { get; set; } = null!;
        public virtual Responsible AResponsible { get; set; } = null!;
        public virtual ICollection<Property> Properties { get; set; }
    }
}
