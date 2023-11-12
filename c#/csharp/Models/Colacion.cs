using System;
using System.Collections.Generic;

namespace csharp.Models
{
    public partial class Colacion
    {
        public Colacion()
        {
            IngredienteDieta = new HashSet<IngredienteDietum>();
        }

        public int Id { get; set; }
        public int DietaId { get; set; }
        public string Tipo { get; set; } = null!;
        public string Horario { get; set; } = null!;

        public virtual DietaOriginal Dieta { get; set; } = null!;
        public virtual ICollection<IngredienteDietum> IngredienteDieta { get; set; }
    }
}
