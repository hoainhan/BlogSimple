using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogSimple.Model.Common
{
    public abstract class BaseEntity { }
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set ; }
    }
}
