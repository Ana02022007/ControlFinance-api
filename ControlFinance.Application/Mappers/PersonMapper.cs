using ControlFinance.Application.DTOs.DTOPerson;
using ControlFinance.Domain.Entities;

namespace ControlFinance.Application.Mappers
{
    public static class PersonMapper
    {
        public static Person ConvertToEntity(this PersonRequest request)
        {
            return new Person
            {
                Name = request.Name,
                BirthDate = request.BirthDate,
            };
        }
        public static PersonResponse ConvertToResponse(this Person person)
        {
            return new PersonResponse
            {
                Id = person.Id,
                Name = person.Name,
                BirthDate = person.BirthDate,
                Transaction = person.Transaction?.Select(t => t.ConvertToResponse())
                .ToList()
            };
        }
        public static PersonListResponse ConvertToListResponse(this Person person)
        {
            return new PersonListResponse
            {
                Id = person.Id,
                Name = person.Name,
                BirthDate = person.BirthDate,
                //Transaction = person.Transaction?.Select(t => t.ConvertToListResponse())
                //.ToList()
            };
        }
    }
}