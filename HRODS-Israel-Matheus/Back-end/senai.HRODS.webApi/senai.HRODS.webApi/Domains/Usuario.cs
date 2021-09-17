using System;
using System.Collections.Generic;

#nullable disable

namespace senai.HRODS.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Players = new HashSet<Player>();
        }

        public int UsuarioId { get; set; }
        public byte? TipoUsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
