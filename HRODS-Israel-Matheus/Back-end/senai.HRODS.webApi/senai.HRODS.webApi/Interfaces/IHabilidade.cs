using senai.HRODS.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Interfaces
{
    interface IHabilidade
    {
        void Cadastrar(Habilidade NovaHabilidade);
        List<Habilidade> ListarTodos();
        Habilidade BuscarPorId(int HabilidadeId);
        void AtualizarIdUrl(int HabilidadeId, Habilidade HabilidadeAtualizada);
        void Deletar(int HabilidadeId);
    }
}
