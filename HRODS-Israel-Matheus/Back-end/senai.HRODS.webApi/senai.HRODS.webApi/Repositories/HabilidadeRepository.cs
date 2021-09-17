using senai.HRODS.webApi.Contexts;
using senai.HRODS.webApi.Domains;
using senai.HRODS.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Repositories
{
    public class HabilidadeRepository : IHabilidade
    {
        HrodsContext ctx = new HrodsContext();
        public void AtualizarIdUrl(int HabilidadeId, Habilidade HabilidadeAtualizada)
        {
            Habilidade HabilidadeBuscada = ctx.Habilidades.Find(HabilidadeId);

            if (HabilidadeBuscada != null)
            {
                HabilidadeBuscada.Nome = HabilidadeAtualizada.Nome;
                ctx.Habilidades.Update(HabilidadeBuscada);
                ctx.SaveChanges();
            }
        }

        public Habilidade BuscarPorId(int HabilidadeId)
        {
            return ctx.Habilidades.FirstOrDefault(e => e.HabilidadeId == HabilidadeId);
        }

        public void Cadastrar(Habilidade NovaHabilidade)
        {
            ctx.Habilidades.Add(NovaHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int HabilidadeId)
        {
            ctx.Habilidades.Remove(BuscarPorId(HabilidadeId));
            ctx.SaveChanges();
        }

        public List<Habilidade> ListarTodos()
        {
            return ctx.Habilidades.ToList();
        }
    }
}
