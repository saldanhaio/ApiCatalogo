using ApiCatalogo.Model;
using APICatalogo.Models;


namespace ApiCatalogo.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
     IEnumerable<Produto> GetProdutosPorCategoria(int id);
    }
}
