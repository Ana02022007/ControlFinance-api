using Borderland.Entities.Enums;
using ControlFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFinance.Application.DTOs.DTOTransaction
{
    // DTO retornado para representar uma transação completa.
    public class TransactionResponse
    {
        // Identificador único da transação.
        public int Id { get; set; }
        // Descrição da transação.
        public string Description { get; set; }
        // Valor monetário da transação.
        public decimal Value { get; set; }
        // Data em que a transação ocorreu.
        public DateTime Date { get; set; }
        // Tipo da transação (receita ou despesa).
        public TypeTransaction Type { get; set; }
        // Id da pessoa associada à transação.
        public int PersonId { get; set; }
        // Id da categoria associada à transação.
        public int CategoriesId { get; set; }
        //nome da categoria
        public string CategoryName { get; set; }
        //nome da pessoa
        public string PersonName { get; set; }
    }
}
