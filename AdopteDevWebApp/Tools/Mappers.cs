using AdopteDevWebApp.Models.Contract;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Tools
{
    public static class Mappers
    {
        public static GetContract ToWebApp(this Contract c)
        {
            return new GetContract
            {
                Id = c.Id,
                Description = c.Description,
                Price = c.Price,
                DeadLine = c.DeadLine
            };
        }

        public static Contract ToWebApi(this CreateContract cc)
        {
            return new Contract
            {
                Id = cc.Id,
                Description = cc.Description,
                Price = cc.Price,
                DeadLine = cc.DeadLine
            };
        }
    }
}
