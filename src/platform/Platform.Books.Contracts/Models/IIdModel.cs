using System;

namespace MicroservicesGrpcExample.Platform.Books.Contracts.Models
{
    /// <summary>
    /// Base model tha has identifier
    /// </summary>
    public interface IIdModel<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Identifier of entity
        /// </summary>
        TKey Id { get; set; }
    }
}