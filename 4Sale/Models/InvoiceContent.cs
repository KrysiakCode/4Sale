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
        public int Quantity { get; set; }

        [Required]
        public int Gross { get; set; }

        [Required]
        public int Vat { get; set; }

        [Required]
        public int Net { get; set; }

        [Required]
        public Invoice Invoice { get; set; }

        public int InvoiceId { get; set; }

        [Required]
        public Item Item { get; set; }
        [Required]
        public int ItemId { get; set; }
    }
}
