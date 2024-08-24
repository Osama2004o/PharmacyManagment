using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyManagment.Models;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(50)]
    public string? ProductName { get; set; }

    [Column("categoryId")]
    public int? CategoryId { get; set; }

    [Column("price")]
    public int? Price { get; set; }

    public int? QuantityInStock { get; set; }

    [Column("description")]
    [StringLength(50)]
    public string? Description { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category? Category { get; set; }
}
