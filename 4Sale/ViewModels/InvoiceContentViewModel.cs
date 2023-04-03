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

        public int InvoiceId { get; set; }
        public int ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Gross { get; set; }

        [Required]
        public int Vat { get; set; }

        [Required]
        public int Net { get; set; }
    }
}
