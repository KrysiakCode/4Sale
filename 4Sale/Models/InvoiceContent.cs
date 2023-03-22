using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4Sale.Models
{
    public class InvoiceContent
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Invoice Invoice { get; set; }

        public int InvoiceId { get; set; }

        [Required]
        public Item Item { get; set; }
        [Required]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(10)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public float Gross { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public float Vat { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public float Net { get; set; }

    }
}
