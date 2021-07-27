namespace MicroservicesGrpcExample.Platform.Books.Contracts.Models
{
    /// <inheritdoc cref="IIdModel{TKey}"/>
    public class IntIdModel : IIdModel<int>
    {
        /// <inheritdoc cref="IIdModel{TKey}.Id"/>
        public int Id { get; set; }
    }
}