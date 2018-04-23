using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSimple.Model.Common
{
    
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
