using senai.HRODS.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Interfaces
{
    interface IPersonagem
    {
        void Cadastrar(Personagem NovoPersonagem);
        List<Personagem> ListarTodos();
        Personagem BuscarPorId(int PersonagemId);
        void AtualizarIdUrl(int PersonagemId, Personagem PersonagemAtualizado);
        void Deletar(int PersonagemId);
    }
}
