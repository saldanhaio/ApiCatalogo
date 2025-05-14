using ApiCatalogo.Model;


namespace ApiCatalogo.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
     IEnumerable<Produto> GetProdutosPorCategoria(int id);
    }
}
