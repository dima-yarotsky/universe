using System;
using System.Collections.Generic;

namespace universe.Models
{
    public partial class Department
    {
        public Department()
        {
            Audiences = new HashSet<Audience>();
        }

        public int DepartmentId { get; set; }
        public string DName { get; set; } = null!;
        public string DBoss { get; set; } = null!;
        public string DPhone { get; set; } = null!;
        public string DOfficeDean { get; set; } = null!;

        public virtual ICollection<Audience> Audiences { get; set; }
    }
}
