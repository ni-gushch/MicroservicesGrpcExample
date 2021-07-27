using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroservicesGrpcExample.Platform.Books.Contracts.Models.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Author : IIdModel<int>
    {
        /// <inheritdoc cref="Id"/>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Author first name
        /// </summary>
        [MaxLength(50)]
        public string FirstName { get; set; }
        /// <summary>
        /// Author last name
        /// </summary>
        [MaxLength(50)]
        public string LastName { get; set; }
        /// <summary>
        /// Author middle name
        /// </summary>
        [MaxLength(50)]
        public string MiddleName { get; set; }
        /// <summary>
        /// Birthday date
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Link to books collection associated with current author
        /// </summary>
        public List<Book> Books { get; set; }
    }
}