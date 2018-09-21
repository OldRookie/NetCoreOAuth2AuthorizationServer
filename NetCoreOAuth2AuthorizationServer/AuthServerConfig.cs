using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace NetCoreOAuth2AuthorizationServer
{
    /// <summary>
    /// Clase que define las configuraciones para solicitar un token de acceso 
    /// y los permisos que se asignaran a cada recurso registrado
    /// <para>Contiene la configuracion basica</para>
    /// </summary>
    public class AuthServerConfig
    {
        /// <summary>
        /// Nombre del recurso que se va a exponer para autorizacion
        /// </summary>
        private const string RESOURCE_NAME = "Net Core API";
        private const string SCOPE_READ = "scope.read";
        private const string SCOPE_WRITE = "scope.write";
        private const string SCOPE_FULL = "scope.full";
        private const string CLIENT_READ_ID = "b93f631bcf8057505cro";
        private const string CLIENT_READ_SECRET = "sololectura";
        private const string CLIENT_WRITE_ID = "b93f631bcf8057505cwr";
        private const string CLIENT_WRITE_SECRET = "soloescritura";
        private const string CLIENT_FULL_ID = "b93f631bcf8057505cfc";
        private const string CLIENT_FULL_SECRET = "fullcontrol";

        /// <summary>
        /// Scope que define los recursos de la Api
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            var apiResourceList = new List<ApiResource>();
            IEnumerable<string> claims = new List<string> { JwtClaimTypes.Scope, JwtClaimTypes.Audience };
            apiResourceList.Add(new ApiResource(SCOPE_READ, RESOURCE_NAME, claims));
            apiResourceList.Add(new ApiResource(SCOPE_WRITE, RESOURCE_NAME, claims));
            apiResourceList.Add(new ApiResource(SCOPE_FULL, RESOURCE_NAME, claims));
            return apiResourceList;
        }

        /// <summary>
        /// Clientes que desean tener acceso a los recursos
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            var clientList = new List<Client>();

            // Cliente solo lectura
            clientList.Add(new Client()
            {
                ClientId = CLIENT_READ_ID,
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret(CLIENT_READ_SECRET.Sha256())
                },
                AllowedScopes = { SCOPE_READ }
            });

            // Cliente solo escritura
            clientList.Add(new Client()
            {
                ClientId = CLIENT_WRITE_ID,
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret(CLIENT_WRITE_SECRET.Sha256())
                },
                AllowedScopes = { SCOPE_WRITE }
            });

            // Cliente Control total
            clientList.Add(new Client()
            {
                ClientId = CLIENT_FULL_ID,
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret(CLIENT_FULL_SECRET.Sha256())
                },
                AllowedScopes = { SCOPE_FULL }
            });

            return clientList;
        }
    }
}
