using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroservicesGrpcExample.Platform.Books.Contracts.Models.Entities
{
    /// <summary>
    /// Model of 
    /// </summary>
    public class Book : IIdModel<int>
    {
        /// <inheritdoc cref="Id"/>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Title of the book
        /// </summary>
        [MaxLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// Book description
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }
        
        [ForeignKey("Fk_Book_Author")]
        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}