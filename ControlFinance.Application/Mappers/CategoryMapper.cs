using Borderland.Entities.Enums;
using ControlFinance.Application.DTOs.DTOCategory;
using ControlFinance.Domain.Entities;
using System;

namespace ControlFinance.Application.Mappers
{
    // Centraliza as conversões entre entidade Category e DTOs de categoria.
    public static class CategoryMapper
    {
        public static Category ConvertToEntity(this CategoryRequest request)
        {
            // Cria uma nova entidade e reaproveita o mapeamento comum.
            return request.ConvertToEntity(new Category());
        }

        public static Category ConvertToEntity(this CategoryRequest request, Category category)
        {
            // Copia os dados recebidos no DTO para a entidade.
            category.Description = request.Description;
            category.Purpose = request.Purpose;
            return category;
        }

        public static CategoryResponse ConvertToResponse(this Category category)
        {
            // Converte a entidade para o DTO de resposta detalhada.
            return new CategoryResponse
            {
                Id = category.Id,
                Description = category.Description,
                Purpose = category.Purpose,
            };
        }

        public static CategoryListResponse ConvertToListResponse(this Category category)
        {
            // Converte a entidade para o DTO usado em listagens.
            return new CategoryListResponse
            {
                Id = category.Id,
                Description = category.Description,
                Purpose = category.Purpose,
            };
        }

        public static CategoryTotalItem ConvertToCategoryTotalItemResponse(this Category category)
        {
            // Soma todas as receitas da categoria.
            var totalRevenue = category.Transactions?
                .Where(t => t.Type == TypeTransaction.RECEITA)
                .Sum(t => t.Value) ?? 0;

            // Soma todas as despesas da categoria.
            var totalExpense = category.Transactions?
                .Where(t => t.Type == TypeTransaction.DESPESA)
                .Sum(t => t.Value) ?? 0;

            // Monta o item de totais com resultado líquido.
            return new CategoryTotalItem
            {
                Id = category.Id,
                Description = category.Description,
                Purpose = category.Purpose,
                TotalRevenue = totalRevenue,
                TotalExpense = totalExpense,
                Total = totalRevenue - totalExpense
            };
        }
    }
}
