using ControlFinance.Application.DTOs.DTOTransaction;
using ControlFinance.Domain.Entities;
using Transaction = ControlFinance.Domain.Entities.Transaction;

namespace ControlFinance.Application.Mappers
{
    public static class TransactionMapper
    {
        //public static Transaction ConvertToEntity(this TransactionRequest request)
        //{
        //    Transaction transaction = new();
        //    transaction = request.ConvertToEntity(transaction);
        //    return transaction;
        //}
        public static Transaction ConvertToEntity(this TransactionRequest request)
        {
            return new Transaction
            {
                Description = request.Description,
                Value = request.Value,
                Date = request.Date,
                Type = request.Type,
                PersonId = request.PersonId,
                CategoriesId = request.CategoriesId
            };
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
        public static TransactionListResponse ConvertToListResponse(Transaction transaction)
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
