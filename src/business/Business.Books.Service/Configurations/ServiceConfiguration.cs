namespace MicroservicesGrpcExample.Client.Configurations
{
    /// <summary>
    /// Configuration for current service
    /// </summary>
    public class ServiceConfiguration
    {
        /// <summary>
        /// Service name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Service version
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Service description
        /// </summary>
        public string Description { get; set; }
    }
}