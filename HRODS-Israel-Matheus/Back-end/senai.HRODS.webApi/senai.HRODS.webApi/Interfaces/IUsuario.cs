using senai.HRODS.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Interfaces
{
    interface IUsuario
    {
        void Cadastrar(Usuario NovoUsuario);
        List<Usuario> ListarTodos();
        Usuario BuscarPorId(int UsuarioId);
        void AtualizarIdUrl(int UsuarioId, Usuario UsuarioAtualizado);
        void Deletar(int UsuarioId);
        public Usuario Login(string email, string senha);
    }
}
