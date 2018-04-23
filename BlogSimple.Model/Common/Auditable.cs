using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogSimple.Model.Common
{
    public abstract class Auditable<T>: Entity<T>,IAuditable
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }
        [ScaffoldColumn(false)]
        [MaxLength(256)]
        public string CreatedBy { get; set; }
        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; }
        [ScaffoldColumn(false)]
        [MaxLength(256)]
        public string UpdatedBy { get; set; }
    }
}
