using Agendamentos.Entidade.Entidades;
using Agendamentos.Repositorio.Interface.IRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Repositorio.Repositorios
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : class, IEntidade
    {
        protected readonly Contexto _contexto;
        protected virtual DbSet<TEntidade> EntitySet { get; }

        public RepositorioBase(Contexto contexto) 
        { 
            _contexto = contexto;
            EntitySet = _contexto.Set<TEntidade>();
        }
        public async Task<TEntidade> Atualizar(TEntidade entidade)
        {
            var entityEntry = EntitySet.Update(entidade);
            await _contexto.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task Deletar(TEntidade entidade)
        {
            EntitySet.Remove(entidade);
            await _contexto.SaveChangesAsync();
        }

        public async Task<TEntidade> Inserir(TEntidade entidade)
        {
            var entityEntry = await EntitySet.AddAsync(entidade);
            await _contexto.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<TEntidade> ObterPorId(object id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async Task<List<TEntidade>> Todos()
        {
            return await EntitySet.ToListAsync();
        }
    }
}
