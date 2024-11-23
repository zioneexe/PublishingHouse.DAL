using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper
{
    public static class AdminEntityMapper
    {
        public static Admin ToEntity(this IAdmin model)
        {
            return new Admin
            {
                AdminId = model.AdminId,
                UserId = model.UserId,
                Department = model.Department
            };
        }
    }
}