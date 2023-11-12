using System;
using System.Collections.Generic;

namespace csharp.Models
{
    public partial class IngredienteC
    {
        public IngredienteC()
        {
            IngredienteDietaCs = new HashSet<IngredienteDietaC>();
        }

        public int Id { get; set; }
        public string? Tipo { get; set; }
        public string? Nombre { get; set; }
        public int? IdImg { get; set; }

        public virtual ImagenCopium? IdImgNavigation { get; set; }
        public virtual ICollection<IngredienteDietaC> IngredienteDietaCs { get; set; }
    }
}
