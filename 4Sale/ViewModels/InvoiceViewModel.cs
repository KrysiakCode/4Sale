using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;

namespace _4Sale.ViewModels;

public class InvoiceViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string InvoiceNo { get; set; }

    [Required]
    public DateTime CreationDate { get; set; }

    [Required]
    [Column(TypeName = "varchar(200)")]
    public string Vendor { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public float TotalGross { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public float TotalVat { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public float TotalNet { get; set; }

    //public List<InvoiceContent> InvoiceElements { get; set; } = new List<InvoiceContent>();

}