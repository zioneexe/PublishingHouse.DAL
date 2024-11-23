using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class QualityMarkEntityMapper
{
    public static QualityMark ToEntity(this IQualityMark model)
    {
        return new QualityMark
        {
            QualityMarkId = model.QualityMarkId,
            Name = model.Name,
        };
    }
}