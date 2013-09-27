using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using MVC4TestOAuth.Models;
using DotNetOpenAuth;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.AspNet.Clients;

namespace MVC4TestOAuth
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();

            //OAuthWebSecurity.RegisterClient(new StackExchangeOpenID());


            Dictionary<string, object> IntuitData = new Dictionary<string, object>();
            IntuitData.Add("IntuitIcon", "~/Images/rotatetrans.png");
            //AuthenticationClientData b = new AuthenticationClientData(new IntuitOpenID(), "Intuit", extraData: IntuitData);
            OAuthWebSecurity.RegisterClient(new IntuitOpenID(), "Intuit", extraData: IntuitData);
        }
    }

   
    public class IntuitOpenID : OpenIdClient
    {


        public IntuitOpenID()
            : base("Intuit", "https://openid.intuit.com/openid/xrds")
        {

        }

        protected override Dictionary<string, string> GetExtraData(IAuthenticationResponse response)
        {
            FetchResponse fetchResponse = response.GetExtension<FetchResponse>();

            if (fetchResponse != null)
            {
                var extraData = new Dictionary<string, string>();
                extraData.Add("email", fetchResponse.GetAttributeValue(WellKnownAttributes.Contact.Email));
                extraData.Add("name", fetchResponse.GetAttributeValue(WellKnownAttributes.Name.FullName));
                return extraData;
            }

            return null;
        }
        protected override void OnBeforeSendingAuthenticationRequest(IAuthenticationRequest request)
        {
            var fetchRequest = new FetchRequest();
            fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
            fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.FullName);
            request.AddExtension(fetchRequest);
        }
    }



    //    var result = OAuthWebSecurity.VerifyAuthentication();
    //result.ExtraData["email"];
    //result.ExtraData["name"];
}
