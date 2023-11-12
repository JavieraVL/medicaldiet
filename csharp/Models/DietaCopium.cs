using System;
using System.Collections.Generic;

namespace csharp.Models
{
    public partial class DietaCopium
    {
        public DietaCopium()
        {
            ColacionCopia = new HashSet<ColacionCopium>();
            ComentarioCopia = new HashSet<ComentarioCopium>();
            IngredienteDietaCs = new HashSet<IngredienteDietaC>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public int? IdComent { get; set; }
        public string? RutPaciente { get; set; }

        public virtual ComentarioCopium? IdComentNavigation { get; set; }
        public virtual Paciente? RutPacienteNavigation { get; set; }
        public virtual ICollection<ColacionCopium> ColacionCopia { get; set; }
        public virtual ICollection<ComentarioCopium> ComentarioCopia { get; set; }
        public virtual ICollection<IngredienteDietaC> IngredienteDietaCs { get; set; }
    }
}
