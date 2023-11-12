using System;
using System.Collections.Generic;

namespace csharp.Models
{
    public partial class ComentarioCopium
    {
        public ComentarioCopium()
        {
            DietaCopia = new HashSet<DietaCopium>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public DateOnly? Fecha { get; set; }
        public TimeOnly? Hora { get; set; }
        public int? IdDietaCopia { get; set; }

        public virtual DietaCopium? IdDietaCopiaNavigation { get; set; }
        public virtual ICollection<DietaCopium> DietaCopia { get; set; }
    }
}
