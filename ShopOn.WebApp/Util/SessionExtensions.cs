using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOn.WebApp.Util
{
    public static class SessionExtensions
    {
        //getting data from session based on a key
        // T accepts any return type
        public static T GetSession<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data == null ? default : JsonConvert.DeserializeObject<T>(data);
        }

        // writing back data into session based on a key
        public static void SetSession<T>(this ISession session, string key, Object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
