using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class OrderRequestRepository(PublishingHouseDbContext context) : IOrderRequestRepository
    {
        public async Task AddAsync(IOrderRequest entity)
        {
            if (entity is OrderRequest orderRequestEntity)
            {
                await context.OrderRequests.AddAsync(orderRequestEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type OrderRequest.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var orderRequest = await context.OrderRequests.FindAsync(id);
            if (orderRequest is not null)
                context.OrderRequests.Remove(orderRequest);
            else
                throw new RepositoryException($"OrderRequest with id {id} was not found.");
        }

        public async Task<IEnumerable<IOrderRequest>> GetAllAsync()
        {
            return await context.OrderRequests
                .Include(or => or.Customer)
                .ToListAsync();
        }

        public async Task<IOrderRequest> GetByIdAsync(int id)
        {
            var orderRequest = await context.OrderRequests
                .Include(or => or.Customer)
                 .FirstOrDefaultAsync(or => or.OrderRequestId == id);

            return orderRequest ?? throw new RepositoryException($"OrderRequest with id {id} was not found.");
        }

        public async Task UpdateAsync(int id, IOrderRequest entity)
        {
            var existingOrderRequest = await context.OrderRequests.FindAsync(id);
            if (existingOrderRequest is not null)
            {
                if (entity is OrderRequest orderRequestEntity)
                {
                    existingOrderRequest.CustomerId = orderRequestEntity.CustomerId;
                    existingOrderRequest.BookName = orderRequestEntity.BookName;
                    existingOrderRequest.AuthorName = orderRequestEntity.AuthorName;
                    existingOrderRequest.Genre = orderRequestEntity.Genre;
                    existingOrderRequest.PublicationYear = orderRequestEntity.PublicationYear;
                    existingOrderRequest.Quantity = orderRequestEntity.Quantity;
                    existingOrderRequest.PrintType = orderRequestEntity.PrintType;
                    existingOrderRequest.PaperType = orderRequestEntity.PaperType;
                    existingOrderRequest.CoverType = orderRequestEntity.CoverType;
                    existingOrderRequest.FasteningType = orderRequestEntity.FasteningType;
                    existingOrderRequest.IsLaminated = orderRequestEntity.IsLaminated;
                    existingOrderRequest.CoverImagePath = orderRequestEntity.CoverImagePath;
                    existingOrderRequest.CompletionDate = orderRequestEntity.CompletionDate;
                    existingOrderRequest.UpdateDateTime = orderRequestEntity.UpdateDateTime;
                }
                else
                {
                    throw new InvalidOperationException("The provided entity is not of type OrderRequest.");
                }
            }
            else
            {
                throw new RepositoryException($"OrderRequest with id {id} was not found.");
            }
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, file.FileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{file.FileName}";
        }

        public async Task<IEnumerable<IOrderRequest>> GetByCustomerIdAsync(int customerId)
        {
            return await context.OrderRequests
                .Where(po => po.CustomerId == customerId)
                .Include(po => po.Customer)
                .ToListAsync();
        }
    }
}
