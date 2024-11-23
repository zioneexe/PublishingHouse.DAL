using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class PrintOrderEntityMapper
{
    public static PrintOrder ToEntity(this IPrintOrder model)
    {
        return new PrintOrder
        {
            OrderId = model.OrderId,
            Number = model.Number,
            PrintType = model.PrintType,
            PaperType = model.PaperType,
            CoverType = model.CoverType,
            FasteningType = model.FasteningType,
            IsLaminated = model.IsLaminated,
            Price = model.Price,
            OrderStatusId = model.OrderStatusId,
            RegistrationDate = model.RegistrationDate,
            CompletionDate = model.CompletionDate,
            CustomerId = model.CustomerId,
            EmployeeId = model.EmployeeId,
        };
    }
}