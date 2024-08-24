using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyManagment.Models;

public partial class Order
{
    [Key]
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? OrderDate { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Orders")]
    public virtual Customer? Customer { get; set; }
}
