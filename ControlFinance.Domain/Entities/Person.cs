using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlFinance.Domain.Entities
{
    [Table(nameof(Person))]
    public class Person
    {
        //identificador único para cada pessoa
        [Key]
        public int Id { get; set; }

        //nome da pessoa, obrigatório e com limite de 200 caracteres
        [Required, MaxLength(200)]
        public string Name { get; set; }

        //data de nascimento da pessoa, obrigatória
        [Required]
        public DateTime BirthDate { get; set; }

        //lista de transações associadas à pessoa
        public List<Transaction> Transaction { get; set; }
    }
}
