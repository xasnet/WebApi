using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Customer
    {
        /// <summary>
        /// ID покупателя
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Имя покупателя
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Firstname { get; init; } = null!;

        /// <summary>
        /// Фамилия покупателя
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Lastname { get; init; } = null!;
    }
}