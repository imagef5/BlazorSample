using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Corona.Domain.Base
{
    public class DomainObject : DomainObject<int>
    {
    }

    public class DomainObject<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public virtual TKey Idx { get; set; }
    }
}
