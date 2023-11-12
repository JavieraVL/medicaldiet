using System;
using System.Collections.Generic;

namespace csharp.Models
{
    public partial class DietaOriginal
    {
        public DietaOriginal()
        {
            Colacions = new HashSet<Colacion>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Pacienterut { get; set; }

        public virtual Paciente? PacienterutNavigation { get; set; }
        public virtual ICollection<Colacion> Colacions { get; set; }
    }
}
