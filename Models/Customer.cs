using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PharmacyManagment.Models;

public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(20)]
    public string CustomerName { get; set; } = null!;

    [StringLength(11)]
    public string Phone { get; set; } = null!;

    [StringLength(20)]
    public string Email { get; set; } = null!;

    [StringLength(10)]
    public string? City { get; set; }

    [StringLength(50)]
    public string Password { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
