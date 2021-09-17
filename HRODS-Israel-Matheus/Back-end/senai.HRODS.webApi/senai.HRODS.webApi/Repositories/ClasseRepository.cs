using senai.HRODS.webApi.Contexts;
using senai.HRODS.webApi.Domains;
using senai.HRODS.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Repositories
{
    public class ClasseRepository : IClasse
    {
        HrodsContext ctx = new HrodsContext();
        public void AtualizarIdUrl(int ClasseId, Classe ClasseAtualizada)
        {
            Classe ClasseBuscada = ctx.Classes.Find(ClasseId);

            if (ClasseBuscada != null)
            {
                ClasseBuscada.Nome = ClasseAtualizada.Nome;
                ctx.Classes.Update(ClasseBuscada);
                ctx.SaveChanges();
            }
        }

        public Classe BuscarPorId(int ClasseId)
        {
            return ctx.Classes.FirstOrDefault(e => e.ClasseId == ClasseId);
        }

        public void Cadastrar(Classe NovaClasse)
        {
            ctx.Classes.Add(NovaClasse);
            ctx.SaveChanges();
        }

        public void Deletar(int ClasseId)
        {
            ctx.Classes.Remove(BuscarPorId(ClasseId));
            ctx.SaveChanges();
        }

        public List<Classe> ListarTodos()
        {
            return ctx.Classes.ToList();
        }
    }
}
