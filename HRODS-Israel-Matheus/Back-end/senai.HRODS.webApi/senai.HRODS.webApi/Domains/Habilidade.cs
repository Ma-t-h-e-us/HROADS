using System;
using System.Collections.Generic;

#nullable disable

namespace senai.HRODS.webApi.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            ClasseHabilidades = new HashSet<ClasseHabilidade>();
        }

        public byte HabilidadeId { get; set; }
        public byte? TipoHabilidadeId { get; set; }
        public string Nome { get; set; }

        public virtual TipoHabilidade TipoHabilidade { get; set; }
        public virtual ICollection<ClasseHabilidade> ClasseHabilidades { get; set; }
    }
}
