namespace NetCoreOAuth2ConsoleClient
{
    /// <summary>
    /// Clase que define las configuraciones para solicitar un token de acceso 
    /// y los permisos que se asignaran a cada recurso registrado
    /// <para>Contiene la configuracion basica</para>
    /// </summary>
    public class AuthServerConfig
    {
        public const string RESOURCE_NAME = "Net Core API";
        public const string SCOPE_READ = "scope.read";
        public const string SCOPE_WRITE = "scope.write";
        public const string SCOPE_FULL = "scope.full";
        public const string CLIENT_READ_ID = "b93f631bcf8057505cro";
        public const string CLIENT_READ_SECRET = "sololectura";
        public const string CLIENT_WRITE_ID = "b93f631bcf8057505cwr";
        public const string CLIENT_WRITE_SECRET = "soloescritura";
        public const string CLIENT_FULL_ID = "b93f631bcf8057505cfc";
        public const string CLIENT_FULL_SECRET = "fullcontrol";
        public const string AUTH_SERVER_URL = "http://localhost:6422";
        public const string AUTH_WEBAPI_URL = "http://localhost:9856";
    }
}
