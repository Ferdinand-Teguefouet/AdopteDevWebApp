using AdopteDevWebApp.Models.Contract;
using AdopteDevWebApp.Models.ProfilDev;
using AdopteDevWebApp.Models.Skill;
using AdopteDevWebApp.Models.User;
using AdopteDevWebApp.Security;
using DataAccess.Entities;
using DataAccess.Entities.FromViewsDb;
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

        public static UserToAdd UserToWebApi(this RegisterModel rm)
        {
            return new UserToAdd
            {
                Id = rm.Id,
                Name = rm.Name,
                Email = rm.Email,
                Password = rm.Password,
                Telephone = rm.Telephone,
                IsClient = rm.IsClient
            };
        }

        public static GetUserModel UserToWebApp(this User u)
        {
            return new GetUserModel
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Token = u.Token,
                Telephone = u.Telephone,
                IsClient = u.IsClient
            };
        }

        public static SkillModel SkillToWebApp(this Skill s)
        {
            return new SkillModel
            {
                Id = s.Id,
                SkillName = s.SkillName,
                Description = s.Description
            };
        }

        public static ProfilDevModel ProfilDevToWebApi(this ProfilDev pd)
        {
            return new ProfilDevModel
            {
                Name = pd.Name,
                Skill = pd.Skill,
                Category = pd.Category,
                Description = pd.Description
            };
        }
    }
}
