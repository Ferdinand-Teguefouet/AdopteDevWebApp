﻿using AdopteDevWebApp.Models.Contract;
using AdopteDevWebApp.Models.Login;
using AdopteDevWebApp.Models.User;
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

        public static Contract ContractToWebApi(this CreateContract cc)
        {
            return new Contract
            {
                Id = cc.Id,
                Description = cc.Description,
                Price = cc.Price,
                DeadLine = cc.DeadLine
            };
        }

        public static User UserToWebApi(this AddUser cu)
        {
            return new User
            {
                Id = cu.Id,
                Name = cu.Name,
                Email = cu.Email,
                Password = cu.Password,
                Telephone = cu.Telephone,
                IsClient = cu.IsClient
            };
        }

        public static GetUserModel UserToWebApp(this User u)
        {
            return new GetUserModel
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Password = u.Password,
                Telephone = u.Telephone,
                IsClient = u.IsClient
            };
        }
    }
}
