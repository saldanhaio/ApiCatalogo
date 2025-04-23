using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiCatalogo.Validations;

namespace ApiCatalogo.Model
{
    [Table("Produtos")]
    public class Produto : IValidatableObject
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
          
        [StringLength(80)]
        [PrimeiraLetraMaiuscula]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }
        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
          if (string.IsNullOrEmpty(Nome))
          {
              yield return new ValidationResult("O campo Nome é obrigatório", new[] { nameof(Nome) });
          }
          if (string.IsNullOrEmpty(Descricao))
          {
              yield return new ValidationResult("O campo Descricao é obrigatório", new[] { nameof(Descricao) });
          }
    
        
       
        }
    }
}