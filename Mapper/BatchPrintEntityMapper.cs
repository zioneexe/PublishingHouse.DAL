using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class BatchPrintEntityMapper
{
    public static BatchPrint ToEntity(this IBatchPrint model)
    {
        return new BatchPrint
        {
            BatchPrintId = model.BatchPrintId,
            Number = model.Number,
            BookQuantity = model.BookQuantity,
            OrderId = model.OrderId,
            PrintDate = model.PrintDate,
            QualityMarkId = model.QualityMarkId
        };
    }
}