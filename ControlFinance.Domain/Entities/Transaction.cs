using Borderland.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlFinance.Domain.Entities
{
    [Table(nameof(Transaction))]

    public class Transaction
    {
        //identificador único para cada transação
        [Key]
        public int Id { get; set; }

        //descrição da transação, obrigatória e com limite de 400 caracteres
        [Required, MaxLength(400)]
        public string Description { get; set; }

        //valor da transação, obrigatório e do tipo decimal para representar valores monetários
        [Required]
        public decimal Value { get; set; }

        //data da transação, obrigatória e do tipo DateTime para representar
        [Required]
        public DateTime Date { get; set; }

        //tipo de transação, obrigatório e do tipo enum para indicar se é uma despesa ou receita
        [Required]
        public TypeTransaction Type { get; set; }

        //referência à pessoa associada à transação, usando chave estrangeira para estabelecer a relação
        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }

        //referência à categoria associada à transação, usando chave estrangeira para estabelecer a relação e obrigatória
        [Required]
        public int CategoriesId { get; set; }
        [ForeignKey(nameof(CategoriesId))]
        public Category Category { get; set; }

    }
}