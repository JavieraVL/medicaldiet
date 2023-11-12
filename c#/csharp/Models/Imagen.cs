using System;
using System.Collections.Generic;

namespace csharp.Models
{
    public partial class Imagen
    {
        public Imagen()
        {
            Ingredientes = new HashSet<Ingrediente>();
        }

        public int Id { get; set; }
        public string? Url { get; set; }

        public virtual ICollection<Ingrediente> Ingredientes { get; set; }
    }
}
