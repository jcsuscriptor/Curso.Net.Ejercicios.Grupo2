namespace Configuraciones
{
    public class ConfiguracionAutentificacion
    {
        public string Key { get; set; }
        public bool Active { get; set; }

        public string Description { get; set; }

        public JwtConfiguration JWT { get; set; }

        public override string ToString()
        {
            return $"Key: {Key}. Active: {Active}. Description {Description} JWT: {JWT}";
        }
    }

    public class JwtConfiguration {
        public string Key { get; set; }

        public override string ToString()
        {
            return $"Key: {Key}";
        }

    } 
}
