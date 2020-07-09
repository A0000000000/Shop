using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace Shop.Tools
{
    public static class JWTTools
    {
        public static string Secret = "Just For Fun";

        private static IJwtAlgorithm algorithm;
        private static IJsonSerializer serializer;
        private static IBase64UrlEncoder urlEncoder;

        private static IJwtEncoder encoder;

        private static IDateTimeProvider provider;
        private static IJwtValidator validator;
        private static IJwtDecoder decoder;


        static JWTTools()
        {
            algorithm = new HMACSHA256Algorithm();
            serializer = new JsonNetSerializer();
            urlEncoder = new JwtBase64UrlEncoder();

            encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            provider = new UtcDateTimeProvider();
            validator = new JwtValidator(serializer, provider);
            decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
        }

        public static string Encode(string username, DateTime dateTime, bool isAdmin = false)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                ["username"] = username,
                ["datetime"] = dateTime
            };
            return encoder.Encode(dic, Secret + (isAdmin ? " admin" : ""));
        }

        public static Tuple<string, DateTime> Decode(string token, bool isAdmin = false)
        {
            try
            {
                string json = decoder.Decode(token, Secret + (isAdmin ? " admin" : ""), true);
                Dictionary<string, object> dic = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
                return new Tuple<string, DateTime>(dic["username"]?.ToString(), DateTime.Parse(dic["datetime"]?.ToString() ?? string.Empty));
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
