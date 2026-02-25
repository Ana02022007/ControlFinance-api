using ControlFinance.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlFinance.Domain.Entities
{
    [Table(nameof(Category))]
    public class Category
    {
        //identificador único para cada categoria
        [Key]
        public int Id { get; set; }

        //descrição da categoria, obrigatória e com limite de 400 caracteres
        [Required, MaxLength(400)]
        public string Description { get; set; }

        //propósito da categoria, obrigatório e do tipo enum para indicar se é uma receita, despesa ou ambas
        [Required]
        public CategoryPurpose Purpose { get; set; }
    }
}
