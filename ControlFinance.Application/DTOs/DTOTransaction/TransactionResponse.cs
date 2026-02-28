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
    public class TransactionResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public TypeTransaction Type { get; set; }
        public int PersonId { get; set; }
        public int CategoriesId { get; set; }
    }
}
