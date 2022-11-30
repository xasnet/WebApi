using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Customer
    {
        /// <summary>
        /// ID покупателя
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Имя покупателя
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; } = null!;

        /// <summary>
        /// Фамилия покупателя
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Lastname { get; init; } = null!;
    }
}