using AdopteDevWebApp.Models.User;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Tools
{
    public static class SessionManager
    {
        public static GetUserModel userModel { get; private set; }
        public static void SetUser(this ISession session, GetUserModel value)
        {
            session.SetString("User", JsonConvert.SerializeObject(value));
            userModel = value;
        }

        public static GetUserModel GetUser(this ISession session)
        {
            return JsonConvert.DeserializeObject<GetUserModel>(session.GetString("User"));
        }

        public static void Disconnect(this ISession session)
        {
            session.Clear();
            userModel = null;
        }
    }
}
