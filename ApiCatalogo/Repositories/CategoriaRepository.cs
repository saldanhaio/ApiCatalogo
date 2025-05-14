using ApiCatalogo.Context;
using ApiCatalogo.Model;
using APICatalogo.Repositories;


namespace ApiCatalogo.Repositories
{
    public class CategoriaRepository : Repository<Categoria>,  ICategoriaRepository
    
    {
      
       public CategoriaRepository(AppDbContext context) :base(context)
         {
           
        }
    
}

}