using Agendamentos.Entidade.Entidades;

namespace Agendamentos.Repositorio.Interface.IRepositorios
{
    public interface IRepositorioBase<TEntidade> where TEntidade : class, IEntidade
    {
        Task<TEntidade> ObterPorId(object id);
        Task<TEntidade> Inserir(TEntidade entidade);
        Task<TEntidade> Atualizar(TEntidade entidade);
        Task Deletar(TEntidade entidade);
        Task<List<TEntidade>> Todos();
    }
}
