using Borderland.Entities.Enums;
using ControlFinance.Application.DTOs.DTOPerson;
using ControlFinance.Application.DTOs.DTOTransaction;
using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Entities.Enums;

namespace ControlFinance.Application.Mappers
{
    // Centraliza as conversões entre entidade Person e DTOs de pessoa.
    public static class PersonMapper
    {
        public static Person ConvertToEntity(this PersonRequest request)
        {
            // Cria uma nova entidade e reaproveita o mapeamento comum.
            return request.ConvertToEntity(new Person());
        }

        public static Person ConvertToEntity(this PersonRequest request, Person person)
        {
            // Copia os dados básicos do DTO para a entidade.
            person.Name = request.Name;
            person.BirthDate = request.BirthDate;

            // Converte a lista de transações do DTO para entidades.
            person.Transaction = request.Transaction?
                .Select(t => t.ConvertToEntity())
                .ToList() ?? new List<Transaction>();

            return person;
        }

        public static PersonResponse ConvertToResponse(this Person person)
        {
            // Converte a entidade para o DTO de resposta detalhada.
            return new PersonResponse
            {
                Id = person.Id,
                Name = person.Name,
                BirthDate = person.BirthDate,
                // Converte as transações associadas para DTOs de resposta.
                Transaction = person.Transaction?.Select(t => t.ConvertToResponse())
                .ToList() ?? new List<TransactionResponse>()
            };
        }

        public static PersonListResponse ConvertToListResponse(this Person person)
        {
            // Converte a entidade para o DTO usado em listagens.
            return new PersonListResponse
            {
                Id = person.Id,
                Name = person.Name,
                BirthDate = person.BirthDate,
            };
        }

        public static PersonTotalItem ConvertToPersonTotalItemResponse(this Person person)
        {
            // Soma todas as receitas da pessoa.
            var totalRevenue = person.Transaction?
                .Where(t => t.Type == TypeTransaction.RECEITA)
                .Sum(t => t.Value) ?? 0;

            // Soma todas as despesas da pessoa.
            var totalExpense = person.Transaction?
                .Where(t => t.Type == TypeTransaction.DESPESA)
                .Sum(t => t.Value) ?? 0;

            // Monta o item de totais com resultado líquido.
            return new PersonTotalItem
            {
                Id = person.Id,
                Name = person.Name,
                TotalRevenue = totalRevenue,
                TotalExpense = totalExpense,
                Total = totalRevenue - totalExpense
            };
        }
    }
}
