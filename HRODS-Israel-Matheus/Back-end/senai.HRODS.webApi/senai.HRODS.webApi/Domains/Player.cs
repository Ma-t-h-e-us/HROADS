using System;
using System.Collections.Generic;

#nullable disable

namespace senai.HRODS.webApi.Domains
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public byte? PersonagemId { get; set; }
        public int? UsuarioId { get; set; }

        public virtual Personagem Personagem { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
