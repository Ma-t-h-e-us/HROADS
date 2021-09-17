using System;
using System.Collections.Generic;

#nullable disable

namespace senai.HRODS.webApi.Domains
{
    public partial class ClasseHabilidade
    {
        public byte ClasseHabilidadeId { get; set; }
        public byte? ClasseId { get; set; }
        public byte? HabilidadeId { get; set; }

        public virtual Classe Classe { get; set; }
        public virtual Habilidade Habilidade { get; set; }
    }
}
