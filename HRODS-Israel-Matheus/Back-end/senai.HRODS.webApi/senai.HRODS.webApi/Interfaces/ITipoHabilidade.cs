using senai.HRODS.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Interfaces
{
    interface ITipoHabilidade
    {
        void Cadastrar(TipoHabilidade NovaTipoHabilidade);
        List<TipoHabilidade> ListarTodos();
        TipoHabilidade BuscarPorId(int TipoHabilidadeId);
        void AtualizarIdUrl(int TipoHabilidadeId, TipoHabilidade TipoHabilidadeAtualizada);
        void Deletar(int TipoHabilidadeId);
    }
}
