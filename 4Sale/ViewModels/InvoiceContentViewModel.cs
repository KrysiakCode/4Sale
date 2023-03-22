using _4Sale.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4Sale.ViewModels
{
    public class InvoiceContentViewModel
    {
        [Required]
        public int Id { get; set; }

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
