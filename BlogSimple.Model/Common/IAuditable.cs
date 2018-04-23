using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSimple.Model.Common
{
    public interface IAuditable
    {
        DateTime CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime UpdatedDate { get; set; }

        string UpdatedBy { get; set; }
    }
}
