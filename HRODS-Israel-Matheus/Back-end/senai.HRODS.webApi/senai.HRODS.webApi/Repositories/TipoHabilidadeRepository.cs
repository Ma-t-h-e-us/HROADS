using senai.HRODS.webApi.Contexts;
using senai.HRODS.webApi.Domains;
using senai.HRODS.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidade
    {
        HrodsContext ctx = new HrodsContext();
        public void AtualizarIdUrl(int TipoHabilidadeId, TipoHabilidade TipoHabilidadeAtualizada)
        {
            Habilidade HabilidadeBuscada = ctx.Habilidades.Find(TipoHabilidadeId);

            if (HabilidadeBuscada != null)
            {
                HabilidadeBuscada.Nome = TipoHabilidadeAtualizada.Nome;
                ctx.Habilidades.Update(HabilidadeBuscada);
                ctx.SaveChanges();
            }
        }

        public TipoHabilidade BuscarPorId(int TipoHabilidadeId)
        {
            return ctx.TipoHabilidades.FirstOrDefault(e => e.TipoHabilidadeId == TipoHabilidadeId);
        }

        public void Cadastrar(TipoHabilidade NovaTipoHabilidade)
        {
            ctx.TipoHabilidades.Add(NovaTipoHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int TipoHabilidadeId)
        {
            ctx.TipoHabilidades.Remove(BuscarPorId(TipoHabilidadeId));
            ctx.SaveChanges();
        }

        public List<TipoHabilidade> ListarTodos()
        {
            return ctx.TipoHabilidades.ToList();
        }
    }
}
