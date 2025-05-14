
using System.Linq.Expressions;

public interface IRepository<T>


{

    //Não violar o principio ISP
    IEnumerable<T> GetAll(); //Indicado para usar em memória
  
    T? Get(Expression<Func<T, bool>> predicate);

    T Create(T entity);

    T Update(T entity);

    T Delete(T entity);
  

}