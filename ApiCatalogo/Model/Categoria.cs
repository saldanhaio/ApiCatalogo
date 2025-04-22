using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Model
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; } 

        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}