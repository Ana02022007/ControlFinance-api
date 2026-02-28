using Borderland.Entities.Enums;
using ControlFinance.Application.DTOs.DTOPerson;
using ControlFinance.Application.DTOs.DTOTransaction;
using ControlFinance.Domain.Entities;
using ControlFinance.Domain.Entities.Enums;

namespace ControlFinance.Application.Mappers
{
    public static class PersonMapper
    {
        public static Person ConvertToEntity(this PersonRequest request)
        {
            return request.ConvertToEntity(new Person());
        }
        public static Person ConvertToEntity(this PersonRequest request, Person person)
        {
            person.Name = request.Name;
            person.BirthDate = request.BirthDate;
            person.Transaction = request.Transaction?
                .Select(t => t.ConvertToEntity())
                .ToList() ?? new List<Transaction>();

            return person;
        }
        public static PersonResponse ConvertToResponse(this Person person)
        {
            return new PersonResponse
            {
                Id = person.Id,
                Name = person.Name,
                BirthDate = person.BirthDate,
                Transaction = person.Transaction?.Select(t => t.ConvertToResponse())
                .ToList() ?? new List<TransactionResponse>()
            };
        }
        public static PersonListResponse ConvertToListResponse(this Person person)
        {
            return new PersonListResponse
            {
                Id = person.Id,
                Name = person.Name,
                BirthDate = person.BirthDate,
            };
        }
        public static PersonTotalItem ConvertToPersonTotalItemResponse(this Person person)
        {
            var totalRevenue = person.Transaction?
                .Where(t => t.Type == TypeTransaction.RECEITA)
                .Sum(t => t.Value) ?? 0;

            var totalExpense = person.Transaction?
                .Where(t => t.Type == TypeTransaction.DESPESA)
                .Sum(t => t.Value) ?? 0;

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
