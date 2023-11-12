using System;
using System.Collections.Generic;

namespace csharp.Models
{
    public partial class IngredienteDietum
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? IdIngr { get; set; }
        public int? ColacionId { get; set; }

        public virtual Colacion? Colacion { get; set; }
        public virtual Ingrediente? IdIngrNavigation { get; set; }
    }
}
