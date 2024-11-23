using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class UserEntityMapper
{
    public static User ToEntity(this IUser model)
    {
        return new User
        {
            UserId = model.UserId,
            RoleId = model.RoleId,
            Username = model.Username,
            PasswordHash = model.PasswordHash,
            FullName = model.FullName,
            Email = model.Email,
            PhoneNumber= model.PhoneNumber,
        };
    }
}