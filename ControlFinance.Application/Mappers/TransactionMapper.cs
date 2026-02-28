using ControlFinance.Application.DTOs.DTOTransaction;
using Transaction = ControlFinance.Domain.Entities.Transaction;

namespace ControlFinance.Application.Mappers
{
    public static class TransactionMapper
    {
        public static Transaction ConvertToEntity(this TransactionRequest request)
        {
               return request.ConvertToEntity(new Transaction());
        }
        public static Transaction ConvertToEntity(this TransactionRequest request, Transaction transaction)
        {
            transaction.Description = request.Description;
            transaction.Value = request.Value;
            transaction.Date = request.Date;
            transaction.Type = request.Type;
            transaction.PersonId = request.PersonId;
            transaction.CategoriesId = request.CategoriesId;
            return transaction;
        }
        public static TransactionResponse ConvertToResponse(this Transaction transaction)
        {
            return new TransactionResponse
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Value = transaction.Value,
                Date = transaction.Date,
                Type = transaction.Type,
                PersonId = transaction.PersonId,
                CategoriesId = transaction.CategoriesId
            };
        }
        public static TransactionListResponse ConvertToListResponse(this Transaction transaction)
        {
            return new TransactionListResponse
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Value = transaction.Value,
                Date = transaction.Date,
                Type = transaction.Type,
                PersonId = transaction.PersonId,
                CategoriesId = transaction.CategoriesId
            };
        }
    }
}
