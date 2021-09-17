using senai.HRODS.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Interfaces
{
    interface IClasse
    {
        void Cadastrar(Classe NovaClasse);
        List<Classe> ListarTodos();
        Classe BuscarPorId(int ClasseId);
        void AtualizarIdUrl(int ClasseId, Classe ClasseAtualizada);
        void Deletar(int ClasseId);
    }
}
