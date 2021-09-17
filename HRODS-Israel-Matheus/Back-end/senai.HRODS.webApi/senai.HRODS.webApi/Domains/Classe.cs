using System;
using System.Collections.Generic;

#nullable disable

namespace senai.HRODS.webApi.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            ClasseHabilidades = new HashSet<ClasseHabilidade>();
            Personagems = new HashSet<Personagem>();
        }

        public byte ClasseId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<ClasseHabilidade> ClasseHabilidades { get; set; }
        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
