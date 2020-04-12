using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Corona.Domain.Entity.Base
{
    public abstract class BoardBase
    {
        [Key]
        public int Seq { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public int ReadNum { get; set; }
    }
}
