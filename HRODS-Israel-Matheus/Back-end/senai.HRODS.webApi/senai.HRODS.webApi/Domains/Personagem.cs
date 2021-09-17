using System;
using System.Collections.Generic;

#nullable disable

namespace senai.HRODS.webApi.Domains
{
    public partial class Personagem
    {
        public Personagem()
        {
            Players = new HashSet<Player>();
        }

        public byte PersonagemId { get; set; }
        public byte? ClasseId { get; set; }
        public string Nome { get; set; }
        public byte CapacidadeMaximaVida { get; set; }
        public byte CapacidadeMaximaMana { get; set; }
        public DateTime DataDeAtualização { get; set; }
        public DateTime DataDeCriacao { get; set; }

        public virtual Classe Classe { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
