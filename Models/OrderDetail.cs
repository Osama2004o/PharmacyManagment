using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyManagment.Models;

[Keyless]
[Table("Order Details")]
public partial class OrderDetail
{
    public int OrderId { get; set; }

    [Column("productId")]
    public int? ProductId { get; set; }

    public int? Ammount { get; set; }

    public int? TotalPrice { get; set; }

    [ForeignKey("OrderId")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    public virtual Product? Product { get; set; }
}
