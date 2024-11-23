using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper
{
    public static class RoleEntityMapper
    {
        public static Role ToEntity(this IRole model)
        {
            return new Role
            {
                RoleId = model.RoleId,
                Name = model.Name,
            };
        }
    }
}
