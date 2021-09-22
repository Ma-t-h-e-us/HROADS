using senai.HRODS.webApi.Contexts;
using senai.HRODS.webApi.Domains;
using senai.HRODS.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    {
        HrodsContext ctx = new HrodsContext();

        public void AtualizarIdUrl(int TipoUsuarioId, TipoUsuario TipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(TipoUsuarioId);

            if (TipoUsuarioBuscado != null)
            {
                TipoUsuarioBuscado.TituloTipoUsuario = TipoUsuarioAtualizado.TituloTipoUsuario;
                ctx.TipoUsuarios.Update(TipoUsuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public TipoUsuario BuscarPorId(int TipoUsuarioId)
        {
            return ctx.TipoUsuarios.FirstOrDefault(e => e.TipoUsuarioId == TipoUsuarioId);
        }

        public void Cadastrar(TipoUsuario NovoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(NovoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int TipoUsuarioId)
        {
            ctx.TipoUsuarios.Remove(BuscarPorId(TipoUsuarioId));
            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
