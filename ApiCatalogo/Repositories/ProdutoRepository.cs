using ApiCatalogo.Context;
using ApiCatalogo.Model;
using ApiCatalogo.Repositories;
using APICatalogo.Models;


namespace APICatalogo.Repositories;

public class ProdutoRepository : Repository <Produto>, IProdutoRepository
{
  
    public ProdutoRepository(AppDbContext context) :base(context)
    {
    
    }

    public IEnumerable<Produto> GetProdutosPorCategoria (int id)
    {
        return GetAll().Where(c => c.CategoriaId == id);
    }
  
}