using System;
using System.Collections.Generic;

namespace csharp.Models
{
    public partial class ColacionCopium
    {
        public int Id { get; set; }
        public int DietaId { get; set; }
        public string Tipo { get; set; } = null!;
        public string Horario { get; set; } = null!;

        public virtual DietaCopium Dieta { get; set; } = null!;
    }
}
