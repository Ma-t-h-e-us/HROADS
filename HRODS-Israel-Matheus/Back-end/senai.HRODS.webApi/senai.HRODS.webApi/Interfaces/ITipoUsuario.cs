using senai.HRODS.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Interfaces
{
    interface ITipoUsuario
    {
        void Cadastrar(TipoUsuario NovoTipoUsuario);
        List<TipoUsuario> ListarTodos();
        TipoUsuario BuscarPorId(int TipoUsuarioId);
        void AtualizarIdUrl(int TipoUsuarioId, TipoUsuario TipoUsuarioAtualizado);
        void Deletar(int TipoUsuarioId);
    }
}
