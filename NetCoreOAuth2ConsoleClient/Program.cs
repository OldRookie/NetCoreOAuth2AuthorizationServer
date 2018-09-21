using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NetCoreOAuth2ConsoleClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Variables a utilizar para la validacion del token
            Uri authorizationServerTokenIssuerUri = new Uri(AuthServerConfig.AUTH_SERVER_URL + "/connect/token");
            string clientId = AuthServerConfig.CLIENT_READ_ID;
            string clientSecret = AuthServerConfig.CLIENT_READ_SECRET;
            string scope = AuthServerConfig.SCOPE_READ;

            // Peticion para obtener el token con el servidor de autorizacion
            string rawJwtToken = RequestTokenToAuthorizationServer(authorizationServerTokenIssuerUri, clientId, scope, clientSecret).GetAwaiter().GetResult();

            AuthorizationServerAnswer authorizationServerToken;
            authorizationServerToken = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthorizationServerAnswer>(rawJwtToken);

            Console.WriteLine("Token obtenido desde el servidor de Autorizacion...");
            Debug.WriteLine(authorizationServerToken.access_token);
            Console.WriteLine(authorizationServerToken.access_token);

            // Peticion para validar el token con la api securizada
            string responseFromApi = RequestValuesToSecuredWebApi(authorizationServerToken).GetAwaiter().GetResult();

            Console.WriteLine("Respuesta recibida de la api protegida...");
            Console.WriteLine(responseFromApi);
            Console.ReadKey();
        }

        /// <summary>
        /// Realiza la peticion al servidor de autenticacion
        /// </summary>
        /// <param name="uriAuthorizationServer"></param>
        /// <param name="clientId"></param>
        /// <param name="scope"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        private static async Task<string> RequestTokenToAuthorizationServer(Uri uriAuthorizationServer, string clientId, string scope, string clientSecret)
        {
            HttpResponseMessage responseMessage;
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage tokenRequest = new HttpRequestMessage(HttpMethod.Post, uriAuthorizationServer);
                HttpContent httpContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("scope", scope),
                    new KeyValuePair<string, string>("client_secret", clientSecret)
                });

                tokenRequest.Content = httpContent;
                responseMessage = await client.SendAsync(tokenRequest);
            }

            return await responseMessage.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Realiza una peticion a la api securizada
        /// </summary>
        /// <param name="authorizationServerToken"></param>
        /// <returns></returns>
        private static async Task<string> RequestValuesToSecuredWebApi(AuthorizationServerAnswer authorizationServerToken)
        {
            HttpResponseMessage responseMessage;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorizationServerToken.access_token);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, AuthServerConfig.AUTH_WEBAPI_URL + "/api/values/1");
                responseMessage = await httpClient.SendAsync(request);
            }

            return await responseMessage.Content.ReadAsStringAsync();
        }
    }
}
