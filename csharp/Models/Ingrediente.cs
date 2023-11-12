using System;
using System.Collections.Generic;

namespace csharp.Models
{
    public partial class Ingrediente
    {
        public Ingrediente()
        {
            IngredienteDieta = new HashSet<IngredienteDietum>();
        }

        public int Id { get; set; }
        public string? Tipo { get; set; }
        public string? Nombre { get; set; }
        public int? IdImg { get; set; }

        public virtual Imagen? IdImgNavigation { get; set; }
        public virtual ICollection<IngredienteDietum> IngredienteDieta { get; set; }
    }
}
