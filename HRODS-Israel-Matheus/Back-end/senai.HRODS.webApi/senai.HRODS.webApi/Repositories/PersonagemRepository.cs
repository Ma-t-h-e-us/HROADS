using senai.HRODS.webApi.Contexts;
using senai.HRODS.webApi.Domains;
using senai.HRODS.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Repositories
{
    public class PersonagemRepository : IPersonagem 
    {
        HrodsContext ctx = new HrodsContext();
        public void AtualizarIdUrl(int PersonagemId, Personagem PersonagemAtualizado)
        {
            Personagem PersonagemBuscado = ctx.Personagems.Find(PersonagemId);

            if (PersonagemBuscado != null)
            {
                PersonagemBuscado.Nome = PersonagemAtualizado.Nome;
                PersonagemBuscado.CapacidadeMaximaVida = PersonagemAtualizado.CapacidadeMaximaVida;
                PersonagemBuscado.CapacidadeMaximaMana = PersonagemAtualizado.CapacidadeMaximaMana;
                PersonagemBuscado.DataDeAtualização = PersonagemAtualizado.DataDeAtualização;
                ctx.Personagems.Update(PersonagemBuscado);
                ctx.SaveChanges();
            }
        }

        public Personagem BuscarPorId(int PersonagemId)
        {
            return ctx.Personagems.FirstOrDefault(e => e.PersonagemId == PersonagemId);
        }

        public void Cadastrar(Personagem NovoPersonagem)
        {
            ctx.Personagems.Add(NovoPersonagem);
            ctx.SaveChanges();
        }

        public void Deletar(int PersonagemId)
        {
            ctx.Personagems.Remove(BuscarPorId(PersonagemId));
            ctx.SaveChanges();
        }

        public List<Personagem> ListarTodos()
        {
            return ctx.Personagems.ToList();
        }
    }
}
