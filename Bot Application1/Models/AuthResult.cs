using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1.Models
{
    [Serializable]
    public class AuthResult
    {
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string UserUniqueId { get; set; }
        public long ExpiresOnUtcTicks { get; set; }
        public byte[] TokenCache { get; set; }

        public static AuthResult FromADALAuthenticationResult(Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationResult authResult, Microsoft.IdentityModel.Clients.ActiveDirectory.TokenCache tokenCache)
        {
            var result = new AuthResult
            {
                AccessToken = authResult.AccessToken,
                UserName = $"{authResult.UserInfo.GivenName} {authResult.UserInfo.FamilyName}",
                UserUniqueId = authResult.UserInfo.UniqueId,
                ExpiresOnUtcTicks = authResult.ExpiresOn.UtcTicks,
                TokenCache = tokenCache.Serialize()
            };

            return result;
        }

        public static AuthResult FromMSALAuthenticationResult(Microsoft.Identity.Client.AuthenticationResult authResult, Microsoft.Identity.Client.TokenCache tokenCache)
        {
            var result = new AuthResult
            {
                AccessToken = authResult.AccessToken,
                UserName = $"{authResult.User.Name}",
                UserUniqueId = authResult.User.Identifier,
                ExpiresOnUtcTicks = authResult.ExpiresOn.UtcTicks,
                TokenCache = tokenCache.Serialize()
            };

            return result;
        }
    }
}