using senai.HRODS.webApi.Contexts;
using senai.HRODS.webApi.Domains;
using senai.HRODS.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        HrodsContext ctx = new HrodsContext();
        public void AtualizarIdUrl(int UsuarioId, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(UsuarioId);

            if (UsuarioBuscado.Email != null || UsuarioBuscado.Senha != null)
            {
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
                ctx.Usuarios.Update(UsuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int UsuarioId)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.UsuarioId == UsuarioId);
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            ctx.Usuarios.Add(NovoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int UsuarioId)
        {
            ctx.Usuarios.Remove(BuscarPorId(UsuarioId));
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
